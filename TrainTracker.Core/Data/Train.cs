using System;
using System.Collections.Generic;

namespace TrainTracker.Core.Data
{
    public partial class Train
    {
        public Train()
        {
            Trips = new HashSet<Trip>();
        }

        public decimal TrainId { get; set; }
        public string RouteNumber { get; set; } = null!;
        public decimal? DisabledSeatCapacity { get; set; }
        public decimal TotalSeatCapacity { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }
    }
}
