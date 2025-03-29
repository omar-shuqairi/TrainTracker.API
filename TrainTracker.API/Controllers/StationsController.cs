using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTracker.Core.Data;
using TrainTracker.Core.Services;
using TrainTracker.Infra.Services;

namespace TrainTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationsController : ControllerBase
    {
        private readonly IStationsService _stationsService;

        public StationsController(IStationsService stationsService)
        {
            _stationsService = stationsService;
        }
        [HttpGet]
        public List<Station> GetAllStations()
        {
            return _stationsService.GetAllStations();
        }

        [HttpGet]
        [Route("getbyId/{id}")]
        public Station GetStationById(int id)
        {
            return _stationsService.GetStationById(id);
        }


        [HttpPost]
        public void CreateStation(Station station)
        {
            _stationsService.CreateStation(station);
        }

        [HttpPut]
        public void UpdateStation(Station station)
        {
            _stationsService.UpdateStation(station);
        }

        [HttpDelete]
        [Route("DeleteStation/{id}")]

        public void DeleteStation(int id)
        {
            _stationsService.DeleteStation(id);
        }

        [HttpGet]
        [Route("GetCountOfStations")]
        public int GetCountOfStations()
        {
            return _stationsService.GetCountOfStations();
        }

        [HttpGet]
        [Route("SearchStationsByName/{name}")]
        public List<Station> SearchStationsByName(string name)
        {
            return _stationsService.SearchStationsByName(name);

        }

    }
}
