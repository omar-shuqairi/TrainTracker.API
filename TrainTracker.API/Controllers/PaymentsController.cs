using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Reflection.Metadata;
using TrainTracker.Core.Data;
using TrainTracker.Core.DTO;
using TrainTracker.Core.Services;
using TrainTracker.Infra.Services;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout;
using System.IO;
using System.Net.Mail;
using System.Net;
namespace TrainTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsService _paymentsService;
        private readonly ITicketsSerivce _ticketsSerivce;
        private readonly ITrainsService _trainsService;
        private readonly string stripeSecretKey = "sk_test_51R8dsqCGN2E7zFcXnVf4h5xmJLh5PkASShD0gJwtezm6U3M0eY66lpvVtsSOMT1Nw43YcIY2AvetaOBo7anRqNDu00jqlLknch";
        private readonly IConfiguration _configuration;
        public PaymentsController(IPaymentsService paymentsService, IConfiguration configuration, ITicketsSerivce ticketsSerivce, ITrainsService trainsService)
        {
            _paymentsService = paymentsService;
            StripeConfiguration.ApiKey = stripeSecretKey;
            _configuration = configuration;
            _ticketsSerivce = ticketsSerivce;
            _trainsService = trainsService;
        }
        [HttpGet]
        public List<Payment> GetAllPayments()
        {
            return _paymentsService.GetAllPayments();
        }

        [HttpGet]
        [Route("getbyId/{id}")]
        public Payment GetPaymentById(int id)
        {
            return _paymentsService.GetPaymentById(id);
        }


        [HttpPost]
        public void CreatePayment(Payment payment)
        {
            _paymentsService.CreatePayment(payment);
        }

        [HttpPut]
        public void UpdatePayment(Payment payment)
        {
            _paymentsService.UpdatePayment(payment);
        }

        [HttpDelete]
        [Route("DeletePayment/{id}")]

        public void DeletePayment(int id)
        {
            _paymentsService.DeletePayment(id);
        }

        [HttpPost("payment")]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequest paymentRequest)
        {
            try
            {
                // Simulate creating a payment using the Stripe API
                var paymentIntentOptions = new PaymentIntentCreateOptions
                {
                    Amount = 1000,
                    Currency = "usd",
                    PaymentMethod = paymentRequest.PaymentMethodId,
                    ConfirmationMethod = "manual",
                    Confirm = true,
                    ReturnUrl = "http://localhost:4200/home"
                };
                var paymentIntentService = new PaymentIntentService();
                var paymentIntent = await paymentIntentService.CreateAsync(paymentIntentOptions);

                if (paymentIntent.Status == "requires_action" && paymentIntent.NextAction?.RedirectToUrl != null)
                {
                    return Ok(new
                    {
                        success = false,
                        requiresAction = true,
                        redirectUrl = paymentIntent.NextAction.RedirectToUrl.Url
                    });
                }

                if (paymentIntent.Status == "succeeded")
                {
                    byte[] pdfBytes = GenerateInvoicePdf(paymentRequest.UsersDetails, paymentRequest.Trip);
                    string subject = "Your Trip Invoice";
                    string body = "<p>Thank you for your payment. Please find your invoice attached.</p>";
                    await SendEmailAsync(paymentRequest.UsersDetails.Email, subject, body, pdfBytes, "Invoice.pdf");
                    byte[] pdfBytes2 = GenerateTicketPdf(paymentRequest.UsersDetails, paymentRequest.Trip, paymentRequest.Trip.TotalSeatCapacity);
                    int newTicketId = _ticketsSerivce.CreateTicket(new Ticket
                    {
                        BookingDate = DateTime.Now,
                        PaymentStatus = "Paid",
                        UserId = paymentRequest.UsersDetails.User_ID,
                        TripId = paymentRequest.Trip.Trip_ID,
                    });
                    _paymentsService.CreatePayment(new Payment
                    {
                        PaymentAmount = paymentRequest.Trip.Ticket_Price,
                        PaymentMethod = "visa",
                        PaymentDate = DateTime.Now,
                        UserId = paymentRequest.UsersDetails.User_ID,
                        TicketId = newTicketId
                    });

                    _trainsService.UpdateSeatCapacity(paymentRequest.Trip.Train_ID);
                    return File(pdfBytes2, "application/pdf", "Ticket.pdf");
                }

                return BadRequest(new { success = false, message = "Payment failed." });
            }
            catch (StripeException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        private byte[] GenerateTicketPdf(UsersDetailsDto user, TripDto trip, int SeatNumber)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    var writer = new PdfWriter(ms);
                    var pdf = new PdfDocument(writer);
                    iText.Layout.Document document = new iText.Layout.Document(pdf);
                    var boldFont = iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);
                    var regularFont = iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);
                    var title = new Paragraph("Ticket Details")
                        .SetFont(boldFont)
                        .SetFontSize(24)
                        .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                        .SetMarginBottom(20);
                    document.Add(title);
                    var lineSeparator = new iText.Layout.Element.LineSeparator(new iText.Kernel.Pdf.Canvas.Draw.SolidLine());
                    lineSeparator.SetMarginBottom(20);
                    document.Add(lineSeparator);


                    var memberInfoTable = new Table(2).UseAllAvailableWidth();
                    memberInfoTable.AddCell(new Cell().Add(new Paragraph("Full Name:").SetFont(boldFont).SetFontSize(12)));
                    memberInfoTable.AddCell(new Cell().Add(new Paragraph($"{user.First_Name} {user.Last_Name}").SetFont(regularFont).SetFontSize(12)));
                    memberInfoTable.AddCell(new Cell().Add(new Paragraph("Email:").SetFont(boldFont).SetFontSize(12)));
                    memberInfoTable.AddCell(new Cell().Add(new Paragraph(user.Email).SetFont(regularFont).SetFontSize(12)));
                    document.Add(memberInfoTable.SetMarginBottom(20));

                    var paymentInfoTable = new Table(2).UseAllAvailableWidth();
                    paymentInfoTable.AddCell(new Cell().Add(new Paragraph("Amount Paid:").SetFont(boldFont).SetFontSize(12)));
                    paymentInfoTable.AddCell(new Cell().Add(new Paragraph(Convert.ToString(trip.Ticket_Price)).SetFont(boldFont).SetFontSize(12)));

                    paymentInfoTable.AddCell(new Cell().Add(new Paragraph("Payment Date:").SetFont(boldFont).SetFontSize(12)));
                    paymentInfoTable.AddCell(new Cell().Add(new Paragraph(Convert.ToString(DateTime.Now)).SetFont(boldFont).SetFontSize(12)));

                    document.Add(paymentInfoTable.SetMarginBottom(20));

                    // Trip info
                    var tripInfoTable = new Table(2).UseAllAvailableWidth();

                    tripInfoTable.AddCell(new Cell().Add(new Paragraph("Departure Time:").SetFont(boldFont).SetFontSize(12)));
                    tripInfoTable.AddCell(new Cell().Add(new Paragraph(Convert.ToString(trip.Departure_Time)).SetFont(regularFont).SetFontSize(12)));

                    tripInfoTable.AddCell(new Cell().Add(new Paragraph("Start Station:").SetFont(boldFont).SetFontSize(12)));
                    tripInfoTable.AddCell(new Cell().Add(new Paragraph(trip.Start_Station_Name).SetFont(regularFont).SetFontSize(12)));

                    tripInfoTable.AddCell(new Cell().Add(new Paragraph("End Station:").SetFont(boldFont).SetFontSize(12)));
                    tripInfoTable.AddCell(new Cell().Add(new Paragraph(trip.End_Station_Name).SetFont(regularFont).SetFontSize(12)));


                    tripInfoTable.AddCell(new Cell().Add(new Paragraph("Start City:").SetFont(boldFont).SetFontSize(12)));
                    tripInfoTable.AddCell(new Cell().Add(new Paragraph(trip.Start_City).SetFont(regularFont).SetFontSize(12)));

                    tripInfoTable.AddCell(new Cell().Add(new Paragraph("Start Area:").SetFont(boldFont).SetFontSize(12)));
                    tripInfoTable.AddCell(new Cell().Add(new Paragraph(trip.Start_Area).SetFont(regularFont).SetFontSize(12)));


                    tripInfoTable.AddCell(new Cell().Add(new Paragraph("End City:").SetFont(boldFont).SetFontSize(12)));
                    tripInfoTable.AddCell(new Cell().Add(new Paragraph(trip.End_City).SetFont(regularFont).SetFontSize(12)));

                    tripInfoTable.AddCell(new Cell().Add(new Paragraph("End Area:").SetFont(boldFont).SetFontSize(12)));
                    tripInfoTable.AddCell(new Cell().Add(new Paragraph(trip.End_Area).SetFont(regularFont).SetFontSize(12)));

                    tripInfoTable.AddCell(new Cell().Add(new Paragraph("Seat Number:").SetFont(boldFont).SetFontSize(12)));
                    tripInfoTable.AddCell(new Cell().Add(new Paragraph(Convert.ToString(SeatNumber)).SetFont(regularFont).SetFontSize(12)));

                    document.Add(tripInfoTable.SetMarginBottom(20));

                    // Footer
                    var footer = new Paragraph("Thank you for booking our Trips!")
                        .SetFont(boldFont)
                        .SetFontSize(12)
                        .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                        .SetMarginTop(30);
                    document.Add(footer);

                    document.Close();

                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                // Log the error details here
                Console.WriteLine("Error generating PDF: " + ex.Message);
                throw new Exception("An error occurred while generating the invoice PDF.");
            }
        }

        private byte[] GenerateInvoicePdf(UsersDetailsDto user, TripDto trip)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    var writer = new PdfWriter(ms);
                    var pdf = new PdfDocument(writer);
                    iText.Layout.Document document = new iText.Layout.Document(pdf);
                    var boldFont = iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);
                    var regularFont = iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);
                    var title = new Paragraph("Invoice")
                        .SetFont(boldFont)
                        .SetFontSize(24)
                        .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                        .SetMarginBottom(20);
                    document.Add(title);
                    var lineSeparator = new iText.Layout.Element.LineSeparator(new iText.Kernel.Pdf.Canvas.Draw.SolidLine());
                    lineSeparator.SetMarginBottom(20);
                    document.Add(lineSeparator);


                    var memberInfoTable = new Table(2).UseAllAvailableWidth();
                    memberInfoTable.AddCell(new Cell().Add(new Paragraph("Full Name:").SetFont(boldFont).SetFontSize(12)));
                    memberInfoTable.AddCell(new Cell().Add(new Paragraph($"{user.First_Name} {user.Last_Name}").SetFont(regularFont).SetFontSize(12)));
                    memberInfoTable.AddCell(new Cell().Add(new Paragraph("Email:").SetFont(boldFont).SetFontSize(12)));
                    memberInfoTable.AddCell(new Cell().Add(new Paragraph(user.Email).SetFont(regularFont).SetFontSize(12)));
                    document.Add(memberInfoTable.SetMarginBottom(20));

                    var paymentInfoTable = new Table(2).UseAllAvailableWidth();
                    paymentInfoTable.AddCell(new Cell().Add(new Paragraph("Amount Paid:").SetFont(boldFont).SetFontSize(12)));
                    paymentInfoTable.AddCell(new Cell().Add(new Paragraph(Convert.ToString(trip.Ticket_Price)).SetFont(boldFont).SetFontSize(12)));

                    paymentInfoTable.AddCell(new Cell().Add(new Paragraph("Payment Date:").SetFont(boldFont).SetFontSize(12)));
                    paymentInfoTable.AddCell(new Cell().Add(new Paragraph(Convert.ToString(DateTime.Now)).SetFont(boldFont).SetFontSize(12)));

                    document.Add(paymentInfoTable.SetMarginBottom(20));
                    // Footer
                    var footer = new Paragraph("Thank you for booking our Trips!")
                        .SetFont(boldFont)
                        .SetFontSize(12)
                        .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                        .SetMarginTop(30);
                    document.Add(footer);

                    document.Close();

                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                // Log the error details here
                Console.WriteLine("Error generating PDF: " + ex.Message);
                throw new Exception("An error occurred while generating the invoice PDF.");
            }
        }

        private async Task SendEmailAsync(string toEmail, string subject, string body, byte[] attachmentData, string attachmentName)
        {
            var emailSettings = _configuration.GetSection("EmailSettings");

            using (var client = new SmtpClient(emailSettings["Host"], int.Parse(emailSettings["Port"])))
            {
                client.Credentials = new NetworkCredential(emailSettings["Username"], emailSettings["Password"]);
                client.EnableSsl = true;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(emailSettings["FromEmail"]),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(toEmail);
                using (var memoryStream = new MemoryStream(attachmentData))
                {
                    var attachment = new Attachment(memoryStream, attachmentName, "application/pdf");
                    mailMessage.Attachments.Add(attachment);

                    await client.SendMailAsync(mailMessage);
                }
            }
        }

    }
}
