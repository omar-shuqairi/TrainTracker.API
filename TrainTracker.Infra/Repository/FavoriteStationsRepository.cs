using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Common;
using TrainTracker.Core.Data;
using TrainTracker.Core.Repository;
using static System.Collections.Specialized.BitVector32;

namespace TrainTracker.Infra.Repository
{
    public class FavoriteStationsRepository : IFavoriteStationsRepository
    {
        private readonly IDbContext _dbContext;
        public FavoriteStationsRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        public void CreateFavoriteStation(FavoriteStation favoriteStation)
        {
            var p = new DynamicParameters();
            p.Add("p_Station_ID", favoriteStation.StationId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_User_ID", favoriteStation.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Favorite_Stations_PKG.CreateFavoriteStation", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteFavoriteStation(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Favorite_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Favorite_Stations_PKG.DeleteFavoriteStation", p, commandType: CommandType.StoredProcedure);
        }

        public List<FavoriteStation> GetAllFavoriteStations()
        {

            IEnumerable<FavoriteStation> result = _dbContext.Connection.Query<FavoriteStation>
            ("Favorite_Stations_PKG.GetAllFavoriteStations", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public FavoriteStation GetFavoriteStationById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Station_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<FavoriteStation> result = _dbContext.Connection.Query<FavoriteStation>
               ("Favorite_Stations_PKG.GetFavoriteStationById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateFavoriteStation(FavoriteStation favoriteStation)
        {

            var p = new DynamicParameters();
            p.Add("p_Favorite_ID", favoriteStation.FavoriteId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Station_ID", favoriteStation.StationId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_User_ID", favoriteStation.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Favorite_Stations_PKG.UpdateFavoriteStation", p, commandType: CommandType.StoredProcedure);
        }
    }
}
