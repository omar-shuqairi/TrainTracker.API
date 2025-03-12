using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;
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
        public void CreateTicket(Ticket ticket)
        {
            _ticketsRepository.CreateTicket(ticket);
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
    }
}
