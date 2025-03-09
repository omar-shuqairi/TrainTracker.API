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

namespace TrainTracker.Infra.Repository
{
    public class StationsRepository : IStationsRepository
    {
        private readonly IDbContext _dbContext;
        public StationsRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        public void CreateStation(Station station)
        {
            var p = new DynamicParameters();
            p.Add("p_Station_Name", station.StationName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Coordinates", station.Coordinates, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_City", station.City, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Stations_PKG.CreateStation", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteStation(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Station_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Stations_PKG.DeleteStation", p, commandType: CommandType.StoredProcedure);
        }

        public List<Station> GetAllStations()
        {
            IEnumerable<Station> result = _dbContext.Connection.Query<Station>
            ("Stations_PKG.GetAllStations", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Station GetStationById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Station_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Station> result = _dbContext.Connection.Query<Station>
               ("Stations_PKG.GetStationById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateStation(Station station)
        {
            var p = new DynamicParameters();
            p.Add("p_Station_ID", station.StationId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Station_Name", station.StationName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Coordinates", station.Coordinates, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_City", station.City, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Stations_PKG.UpdateStation", p, commandType: CommandType.StoredProcedure);
        }
    }
}
