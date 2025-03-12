using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;

namespace TrainTracker.Core.Repository
{
    public interface IFavoriteStationsRepository
    {
        List<FavoriteStation> GetAllFavoriteStations();
        void CreateFavoriteStation(FavoriteStation favoriteStation);
        void UpdateFavoriteStation(FavoriteStation favoriteStation);
        void DeleteFavoriteStation(int id);
        FavoriteStation GetFavoriteStationById(int id);
    }
}
