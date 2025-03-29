using System;
using System.Collections.Generic;

namespace TrainTracker.Core.Data
{
    public partial class Station
    {
        public Station()
        {
            FavoriteStations = new HashSet<FavoriteStation>();
            TripEndStations = new HashSet<Trip>();
            TripStartStations = new HashSet<Trip>();
        }

        public decimal StationId { get; set; }
        public string StationName { get; set; } = null!;
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? City { get; set; }
        public string? Area { get; set; }

        public virtual ICollection<FavoriteStation> FavoriteStations { get; set; }
        public virtual ICollection<Trip> TripEndStations { get; set; }
        public virtual ICollection<Trip> TripStartStations { get; set; }
    }
}
