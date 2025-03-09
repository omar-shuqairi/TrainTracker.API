using System;
using System.Collections.Generic;

namespace TrainTracker.Core.Data
{
    public partial class Payment
    {
        public decimal PaymentId { get; set; }
        public decimal PaymentAmount { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public DateTime? PaymentDate { get; set; }
        public decimal? TicketId { get; set; }
        public decimal? UserId { get; set; }

        public virtual Ticket? Ticket { get; set; }
        public virtual User? User { get; set; }
    }
}
