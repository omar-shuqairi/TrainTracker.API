using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTracker.Core.Data;
using TrainTracker.Core.DTO;
using TrainTracker.Core.Services;
using TrainTracker.Infra.Services;

namespace TrainTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripsService _tripsService;

        public TripsController(ITripsService tripsService)
        {
            _tripsService = tripsService;
        }
        [HttpGet]
        [Authorize]
        [CheckClaimsAtt("RoleId", "1")]
        public List<TripDto> GetAllTrips()
        {
            return _tripsService.GetAllTrips();
        }

        [HttpGet]
        [Route("getbyId/{id}")]
        public Trip GetTripById(int id)
        {
            return _tripsService.GetTripById(id);
        }


        [HttpPost]
        [Authorize]
        [CheckClaimsAtt("RoleId", "1")]
        public void CreateTrip(Trip trip)
        {
            _tripsService.CreateTrip(trip);
        }

        [HttpPut]
        [Authorize]
        [CheckClaimsAtt("RoleId", "1")]
        public void UpdateTrip(Trip trip)
        {
            _tripsService.UpdateTrip(trip);
        }

        [HttpDelete]
        [Authorize]
        [CheckClaimsAtt("RoleId", "1")]
        [Route("DeleteTrip/{id}")]
        public void DeleteTrip(int id)
        {
            _tripsService.DeleteTrip(id);
        }

        [HttpGet("GetTripsBetweenDates")]
        [Authorize]
        [CheckClaimsAtt("RoleId", "1")]
        public List<TripDto> GetTripsBetweenDates(DateTime? startDate, DateTime? endDate)
        {
            return _tripsService.GetTripsBetweenDates(startDate, endDate);
        }

        [HttpGet]
        [Route("GetAllTripsUpToDate")]
        public List<TripDto> GetAllTripsUpToDate()
        {
            return _tripsService.GetAllTripsUpToDate();
        }
    }
}
