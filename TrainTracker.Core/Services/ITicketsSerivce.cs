using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;
using TrainTracker.Core.DTO;

namespace TrainTracker.Core.Services
{
    public interface ITicketsSerivce
    {
        List<Ticket> GetAllTickets();
        int CreateTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);
        void DeleteTicket(int id);
        Ticket GetTicketById(int id);

        List<ReportDto> GetReport(string type, string year, string month);
    }
}
