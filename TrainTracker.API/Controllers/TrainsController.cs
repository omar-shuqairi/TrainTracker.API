using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTracker.Core.Data;
using TrainTracker.Core.Services;
using TrainTracker.Infra.Services;

namespace TrainTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainsController : ControllerBase
    {
        private readonly ITrainsService _TrainsService;

        public TrainsController(ITrainsService trainsService)
        {
            _TrainsService = trainsService;
        }
        [HttpGet]
        public List<Train> GetAllTrains()
        {
            return _TrainsService.GetAllTrains();
        }

        [HttpGet]
        [Route("getbyId/{id}")]
        public Train GetTrainById(int id)
        {
            return _TrainsService.GetTrainById(id);
        }


        [HttpPost]
        public void CreateTrain(Train train)
        {
            _TrainsService.CreateTrain(train);
        }

        [HttpPut]
        public void UpdateTrain(Train train)
        {
            _TrainsService.UpdateTrain(train);
        }

        [HttpDelete]
        [Route("DeleteTrain/{id}")]

        public void DeleteTrain(int id)
        {
            _TrainsService.DeleteTrain(id);
        }

        [HttpPut]
        [Route("UpdateSeatCapacity/{id}")]
        public void UpdateSeatCapacity(int id)
        {
            _TrainsService.UpdateSeatCapacity(id);
        }
    }
}
