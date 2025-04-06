using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;
using TrainTracker.Core.DTO;
using TrainTracker.Core.Repository;
using TrainTracker.Core.Services;

namespace TrainTracker.Infra.Services
{
    public class TicketsSerivce : ITicketsSerivce
    {
        private readonly ITicketsRepository _ticketsRepository;

        public TicketsSerivce(ITicketsRepository ticketsRepository)
        {
            _ticketsRepository = ticketsRepository;
        }
        public int CreateTicket(Ticket ticket)
        {
            return _ticketsRepository.CreateTicket(ticket);
        }

        public void DeleteTicket(int id)
        {
            _ticketsRepository.DeleteTicket(id);
        }

        public List<Ticket> GetAllTickets()
        {
            return _ticketsRepository.GetAllTickets();
        }


        public Ticket GetTicketById(int id)
        {
            return _ticketsRepository.GetTicketById(id);
        }

        public void UpdateTicket(Ticket ticket)
        {
            _ticketsRepository.UpdateTicket(ticket);
        }
        public List<ReportDto> GetReport(string type, string year, string month)
        {
            return _ticketsRepository.GetReport(type, year, month);
        }
    }
}
