using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;

namespace TrainTracker.Core.Repository
{
    public interface ITripsRepository
    {
        List<Trip> GetAllTrips();
        void CreateTrip(Trip trip);
        void UpdateTrip(Trip trip);
        void DeleteTrip(int id);
        Trip GetTripById(int id);
    }
}
