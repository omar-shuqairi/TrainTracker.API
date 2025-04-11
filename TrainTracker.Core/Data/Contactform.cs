using System;
using System.Collections.Generic;

namespace TrainTracker.Core.Data
{
    public partial class Contactform
    {
        public decimal Id { get; set; }
        public string Fullname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Message { get; set; } = null!;
        public DateTime? Datesubmitted { get; set; }
    }
}
