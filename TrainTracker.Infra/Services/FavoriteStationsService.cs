using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;
using TrainTracker.Core.Repository;
using TrainTracker.Core.Services;

namespace TrainTracker.Infra.Services
{
    public class FavoriteStationsService : IFavoriteStationsService
    {
        private readonly IFavoriteStationsRepository _favoriteStationsRepository;

        public FavoriteStationsService(IFavoriteStationsRepository favoriteStationsRepository)
        {
            _favoriteStationsRepository = favoriteStationsRepository;
        }
        public void CreateFavoriteStation(FavoriteStation favoriteStation)
        {
            _favoriteStationsRepository.CreateFavoriteStation(favoriteStation);
        }

        public void DeleteFavoriteStation(int id)
        {
            _favoriteStationsRepository.DeleteFavoriteStation(id);
        }

        public List<FavoriteStation> GetAllFavoriteStations()
        {
            return _favoriteStationsRepository.GetAllFavoriteStations();
        }

        public FavoriteStation GetFavoriteStationById(int id)
        {
            return _favoriteStationsRepository.GetFavoriteStationById(id);
        }

        public void UpdateFavoriteStation(FavoriteStation favoriteStation)
        {
            _favoriteStationsRepository.UpdateFavoriteStation(favoriteStation);
        }
    }
}
