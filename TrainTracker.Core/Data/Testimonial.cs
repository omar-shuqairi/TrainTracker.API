using System;
using System.Collections.Generic;

namespace TrainTracker.Core.Data
{
    public partial class Testimonial
    {
        public decimal TestimonialId { get; set; }
        public string? TestimonialText { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public decimal? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
