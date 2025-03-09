using System;
using System.Collections.Generic;

namespace TrainTracker.Core.Data
{
    public partial class Trip
    {
        public Trip()
        {
            Tickets = new HashSet<Ticket>();
        }

        public decimal TripId { get; set; }
        public DateTime DepartureTime { get; set; }
        public decimal TicketPrice { get; set; }
        public string? TripDescription { get; set; }
        public decimal? TrainId { get; set; }
        public decimal? StartStationId { get; set; }
        public decimal? EndStationId { get; set; }

        public virtual Station? EndStation { get; set; }
        public virtual Station? StartStation { get; set; }
        public virtual Train? Train { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
