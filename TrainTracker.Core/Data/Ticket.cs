using System;
using System.Collections.Generic;

namespace TrainTracker.Core.Data
{
    public partial class Ticket
    {
        public Ticket()
        {
            Payments = new HashSet<Payment>();
        }

        public decimal TicketId { get; set; }
        public DateTime? BookingDate { get; set; }
        public string? PaymentStatus { get; set; }
        public decimal? UserId { get; set; }
        public decimal? TripId { get; set; }

        public virtual Trip? Trip { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
