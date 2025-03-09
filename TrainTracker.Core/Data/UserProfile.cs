using System;
using System.Collections.Generic;

namespace TrainTracker.Core.Data
{
    public partial class UserProfile
    {
        public decimal ProfileId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ProfileImage { get; set; }
        public string? City { get; set; }
        public decimal? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
