using System;
using System.Collections.Generic;

namespace TrainTracker.Core.Data
{
    public partial class ContactPage
    {
        public decimal ContactId { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
