using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTracker.Core.Data;
using TrainTracker.Core.Services;
using TrainTracker.Infra.Services;

namespace TrainTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteStationsController : ControllerBase
    {
        private readonly IFavoriteStationsService _favoriteStationsService;
        public FavoriteStationsController(IFavoriteStationsService favoriteStationsService)
        {
            _favoriteStationsService = favoriteStationsService;
        }
        [HttpGet]
        public List<FavoriteStation> GetAllFavoriteStations()
        {
            return _favoriteStationsService.GetAllFavoriteStations();
        }

        [HttpGet]
        [Route("getbyId/{id}")]
        public FavoriteStation GetFavoriteStationById(int id)
        {
            return _favoriteStationsService.GetFavoriteStationById(id);
        }


        [HttpPost]
        public void CreateFavoriteStation(FavoriteStation favoriteStation)
        {
            _favoriteStationsService.CreateFavoriteStation(favoriteStation);
        }

        [HttpPut]
        public void UpdateFavoriteStation(FavoriteStation favoriteStation)
        {
            _favoriteStationsService.UpdateFavoriteStation(favoriteStation);
        }

        [HttpDelete]
        [Route("DeleteFavoriteStation/{id}")]

        public void DeleteStation(int id)
        {
            _favoriteStationsService.DeleteFavoriteStation(id);
        }
    }
}
