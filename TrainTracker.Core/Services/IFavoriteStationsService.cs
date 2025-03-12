using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;

namespace TrainTracker.Core.Services
{
    public interface IFavoriteStationsService
    {
        List<FavoriteStation> GetAllFavoriteStations();
        void CreateFavoriteStation(FavoriteStation favoriteStation);
        void UpdateFavoriteStation(FavoriteStation favoriteStation);
        void DeleteFavoriteStation(int id);
        FavoriteStation GetFavoriteStationById(int id);
    }
}
