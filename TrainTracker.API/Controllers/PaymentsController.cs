using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTracker.Core.Data;
using TrainTracker.Core.Services;
using TrainTracker.Infra.Services;

namespace TrainTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsService _paymentsService;

        public PaymentsController(IPaymentsService paymentsService)
        {
            _paymentsService = paymentsService;
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
    }
}
