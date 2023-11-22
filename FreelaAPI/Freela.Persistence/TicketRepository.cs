using Freela.Domain.Models;
using Freela.Persistence.Repository;
using FreelaAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freela.Persistence
{
    public class TicketRepository : ITicketRepository
    {
        private readonly FreelaContext _context;

        public TicketRepository(FreelaContext context)
        {
            _context = context;
        }
        public async Task<Ticket[]> GetAllTicketsBySessionAsync(int sessionId)
        {
            IQueryable<Ticket> query = _context.Ticket;
            query = query
                .OrderBy(p => p.Id)
                .Where(p => p.SessionId == sessionId);

            return await query.ToArrayAsync();
        }

        public async Task<Ticket[]> GetAllTickets()
        {
            IQueryable<Ticket> query = _context.Ticket;
            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Ticket> GetTicketByIdAsync(int Id)
        {
            IQueryable<Ticket> query = _context.Ticket;
            query = query.OrderBy(p => p.Id).Where(p => p.Id == Id);

            return await query.FirstOrDefaultAsync();
        }

    }
}
