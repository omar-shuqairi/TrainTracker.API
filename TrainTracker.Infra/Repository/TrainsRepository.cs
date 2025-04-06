using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Common;
using TrainTracker.Core.Data;
using TrainTracker.Core.Repository;
using static System.Collections.Specialized.BitVector32;

namespace TrainTracker.Infra.Repository
{
    public class TrainsRepository : ITrainsRepository
    {
        private readonly IDbContext _dbContext;
        public TrainsRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        public void CreateTrain(Train train)
        {
            var p = new DynamicParameters();
            p.Add("p_Route_Number", train.RouteNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Disabled_Seat_Capacity", train.DisabledSeatCapacity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Total_Seat_Capacity", train.TotalSeatCapacity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Trains_PKG.CreateTrain", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteTrain(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Train_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Trains_PKG.DeleteTrain", p, commandType: CommandType.StoredProcedure);
        }

        public List<Train> GetAllTrains()
        {
            IEnumerable<Train> result = _dbContext.Connection.Query<Train>
           ("Trains_PKG.GetAllTrains", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Train GetTrainById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Train_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Train> result = _dbContext.Connection.Query<Train>
               ("Trains_PKG.GetTrainById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateTrain(Train train)
        {
            var p = new DynamicParameters();
            p.Add("p_Train_ID", train.TrainId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Route_Number", train.RouteNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Disabled_Seat_Capacity", train.DisabledSeatCapacity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Total_Seat_Capacity", train.TotalSeatCapacity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Trains_PKG.UpdateTrain", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateSeatCapacity(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Train_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Trains_PKG.UpdateSeatCapacity", p, commandType: CommandType.StoredProcedure);
        }
    }
}
