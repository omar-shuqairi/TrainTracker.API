using System;
using System.Collections.Generic;

namespace TrainTracker.Core.Data
{
    public partial class FavoriteStation
    {
        public decimal FavoriteId { get; set; }
        public decimal? StationId { get; set; }
        public decimal? UserId { get; set; }

        public virtual Station? Station { get; set; }
        public virtual User? User { get; set; }
    }
}
