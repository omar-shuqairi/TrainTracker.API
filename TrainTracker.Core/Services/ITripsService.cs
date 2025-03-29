using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;

namespace TrainTracker.Core.Services
{
    public interface ITripsService
    {
        List<Trip> GetAllTrips();
        void CreateTrip(Trip trip);
        void UpdateTrip(Trip trip);
        void DeleteTrip(int id);
        Trip GetTripById(int id);
        List<Trip> GetTripsBetweenDates(DateTime? startDate, DateTime? endDate);

    }
}
