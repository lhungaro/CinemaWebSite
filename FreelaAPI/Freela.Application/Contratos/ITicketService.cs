using Freela.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freela.Application.Contratos
{
    public interface ITicketService
    {
        Task<Ticket> AddTicket(Ticket model);
        Task<Ticket> UpdateTicket(int ticketId, Ticket model);
        Task <bool> DeleteTicket(int ticketId);
        Task<Ticket[]> GetAllTickets();
        Task<Ticket[]> GetAllTicketsBySessionAsync(int sessionId);
        Task<Ticket> GetTicketByIdAsync(int Id);

    }
}
