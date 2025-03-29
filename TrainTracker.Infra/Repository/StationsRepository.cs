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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            p.Add("p_Latitude", station.Latitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_Longitude", station.Longitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_city", station.City, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_area", station.Area, dbType: DbType.String, direction: ParameterDirection.Input);
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
            p.Add("p_Latitude", station.Latitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_Longitude", station.Longitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_city", station.City, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_area", station.Area, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Stations_PKG.UpdateStation", p, commandType: CommandType.StoredProcedure);
        }

        public int GetCountOfStations()
        {
            var p = new DynamicParameters();
            p.Add("station_count", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("Stations_PKG.GetNumberOfStations", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("station_count");

        }

        public List<Station> SearchStationsByName(string name)
        {
            var p = new DynamicParameters();
            p.Add("p_name", name, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Station> result = _dbContext.Connection.Query<Station>
               ("Stations_PKG.SearchStationsByName", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
