using Freela.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freela.Persistence.Repository
{
    public interface ITicketRepository
    {
        Task<Ticket> GetTicketByIdAsync(int Id);
        Task<Ticket[]> GetAllTickets();
        Task<Ticket[]> GetAllTicketsBySessionAsync(int sessionId);

    }
}
