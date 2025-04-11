using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTracker.Core.Data;
using TrainTracker.Core.DTO;
using TrainTracker.Core.Services;
using TrainTracker.Infra.Services;

namespace TrainTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketsSerivce _ticketsSerivce;

        public TicketsController(ITicketsSerivce ticketsSerivce)
        {
            _ticketsSerivce = ticketsSerivce;
        }
        [HttpGet]
        public List<Ticket> GetAllTickets()
        {
            return _ticketsSerivce.GetAllTickets();
        }

        [HttpGet]
        [Route("getbyId/{id}")]
        public Ticket GetTicketById(int id)
        {
            return _ticketsSerivce.GetTicketById(id);
        }


        [HttpPost]
        public void CreateTicket(Ticket ticket)
        {
            _ticketsSerivce.CreateTicket(ticket);
        }

        [HttpPut]
        public void UpdateTicket(Ticket ticket)
        {
            _ticketsSerivce.UpdateTicket(ticket);
        }

        [HttpDelete]
        [Route("DeleteTicket/{id}")]

        public void DeleteTicket(int id)
        {
            _ticketsSerivce.DeleteTicket(id);
        }

        [HttpGet]
        [Authorize]
        [CheckClaimsAtt("RoleId", "1")]
        [Route("GetReport")]
        public List<ReportDto> GetReport([FromQuery] string type, [FromQuery] string year, [FromQuery] string? month)
        {
            return _ticketsSerivce.GetReport(type, year, month);
        }
    }
}
