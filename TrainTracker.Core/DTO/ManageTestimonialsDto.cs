using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTracker.Core.DTO
{
    public class ManageTestimonialsDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TestimonialId { get; set; }
        public string TestimonialText { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
