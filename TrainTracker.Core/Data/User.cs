using System;
using System.Collections.Generic;

namespace TrainTracker.Core.Data
{
    public partial class User
    {
        public User()
        {
            FavoriteStations = new HashSet<FavoriteStation>();
            Payments = new HashSet<Payment>();
            Testimonials = new HashSet<Testimonial>();
            Tickets = new HashSet<Ticket>();
        }

        public decimal UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public decimal? RoleId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual UserProfile? UserProfile { get; set; }
        public virtual ICollection<FavoriteStation> FavoriteStations { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
