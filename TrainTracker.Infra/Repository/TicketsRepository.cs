﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Common;
using TrainTracker.Core.Data;
using TrainTracker.Core.DTO;
using TrainTracker.Core.Repository;
using static System.Collections.Specialized.BitVector32;

namespace TrainTracker.Infra.Repository
{
    public class TicketsRepository : ITicketsRepository
    {
        private readonly IDbContext _dbContext;
        public TicketsRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        public int CreateTicket(Ticket ticket)
        {
            var p = new DynamicParameters();
            p.Add("p_User_ID", ticket.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_Booking_Date", ticket.BookingDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_Trip_ID", ticket.TripId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Payment_Status", ticket.PaymentStatus, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Ticket_ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("Tickets_PKG.CreateTicket", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("p_Ticket_ID");

        }
        public void DeleteTicket(int id)
        {

            var p = new DynamicParameters();
            p.Add("p_Ticket_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Tickets_PKG.DeleteTicket", p, commandType: CommandType.StoredProcedure);
        }

        public List<Ticket> GetAllTickets()
        {
            IEnumerable<Ticket> result = _dbContext.Connection.Query<Ticket>
           ("Tickets_PKG.GetAllTickets", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Ticket GetTicketById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Ticket_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Ticket> result = _dbContext.Connection.Query<Ticket>
               ("Tickets_PKG.GetTicketById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateTicket(Ticket ticket)
        {
            var p = new DynamicParameters();
            p.Add("p_Ticket_ID", ticket.TicketId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("booking_date", ticket.BookingDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_User_ID", ticket.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Trip_ID", ticket.TripId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Payment_Status", ticket.PaymentStatus, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Tickets_PKG.UpdateTicket", p, commandType: CommandType.StoredProcedure);
        }

        public List<ReportDto> GetReport(string type, string year, string month)
        {
            string monthParam = string.IsNullOrEmpty(month) ? string.Empty : month;
            var p = new DynamicParameters();
            p.Add("p_type", type, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_year", year, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_month", monthParam, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<ReportDto> result = _dbContext.Connection.Query<ReportDto>
          ("Tickets_PKG.GetReport",p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
