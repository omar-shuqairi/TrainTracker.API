using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;
using TrainTracker.Core.DTO;
using TrainTracker.Core.Repository;
using TrainTracker.Core.Services;

namespace TrainTracker.Infra.Services
{
    public class TripsService : ITripsService
    {
        private readonly ITripsRepository _tripsRepository;

        public TripsService(ITripsRepository tripsRepository)
        {
            _tripsRepository = tripsRepository;
        }
        public void CreateTrip(Trip trip)
        {
            _tripsRepository.CreateTrip(trip);
        }

        public void DeleteTrip(int id)
        {
            _tripsRepository.DeleteTrip(id);
        }

        public List<Trip> GetAllTrips()
        {
            return _tripsRepository.GetAllTrips();
        }

        public Trip GetTripById(int id)
        {
            return _tripsRepository.GetTripById(id);
        }

        public void UpdateTrip(Trip trip)
        {
            _tripsRepository.UpdateTrip(trip);
        }
        public List<Trip> GetTripsBetweenDates(DateTime? startDate, DateTime? endDate)
        {
            return _tripsRepository.GetTripsBetweenDates(startDate, endDate);
        }

        public List<TripDto> GetAllTripsUpToDate()
        {
            return _tripsRepository.GetAllTripsUpToDate();
        }
    }
}
