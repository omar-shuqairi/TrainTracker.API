using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Common;
using TrainTracker.Core.Data;
using TrainTracker.Core.DTO;
using TrainTracker.Core.Repository;
using static System.Collections.Specialized.BitVector32;

namespace TrainTracker.Infra.Repository
{
    public class TripsRepository : ITripsRepository
    {
        private readonly IDbContext _dbContext;
        public TripsRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        public void CreateTrip(Trip trip)
        {
            var p = new DynamicParameters();
            p.Add("p_Departure_Time", trip.DepartureTime, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_Ticket_Price", trip.TicketPrice, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Trip_Description", trip.TripDescription, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Train_ID", trip.TrainId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Start_Station_ID", trip.StartStationId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_End_Station_ID", trip.EndStationId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Trips_PKG.CreateTrip", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteTrip(int id)
        {

            var p = new DynamicParameters();
            p.Add("p_Trip_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Trips_PKG.DeleteTrip", p, commandType: CommandType.StoredProcedure);
        }

        public List<Trip> GetAllTrips()
        {
            IEnumerable<Trip> result = _dbContext.Connection.Query<Trip>
            ("Trips_PKG.GetAllTrips", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Trip GetTripById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Trip_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Trip> result = _dbContext.Connection.Query<Trip>
               ("Trips_PKG.GetTripById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }


        public void UpdateTrip(Trip trip)
        {
            var p = new DynamicParameters();
            p.Add("p_Trip_ID", trip.TripId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Departure_Time", trip.DepartureTime, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_Ticket_Price", trip.TicketPrice, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Trip_Description", trip.TripDescription, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Train_ID", trip.TrainId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Start_Station_ID", trip.StartStationId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_End_Station_ID", trip.EndStationId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Trips_PKG.UpdateTrip", p, commandType: CommandType.StoredProcedure);
        }
        public List<Trip> GetTripsBetweenDates(DateTime? startDate, DateTime? endDate)
        {
            var p = new DynamicParameters();
            if (startDate.HasValue)
            {
                p.Add("p_start_date", startDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            }
            else
            {
                p.Add("p_start_date", DBNull.Value, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            }

            if (endDate.HasValue)
            {
                p.Add("p_end_date", endDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            }
            else
            {
                p.Add("p_end_date", DBNull.Value, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            }

            IEnumerable<Trip> result = _dbContext.Connection.Query<Trip>("Trips_PKG.GetTripsBetweenDates", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<TripDto> GetAllTripsUpToDate()
        {
            IEnumerable<TripDto> result = _dbContext.Connection.Query<TripDto>
           ("Trips_PKG.GetAllTripsUpToDate", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
