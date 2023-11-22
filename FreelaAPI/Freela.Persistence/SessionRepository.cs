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
    public class SessionRepository : ISessionRepository
    {
        private readonly FreelaContext _context;

        public SessionRepository(FreelaContext context)
        {
            _context = context;
        }
        public async Task<Session[]> GetAllFreelaByAreaAsync(string Area)
        {
            IQueryable<Session> query = _context.Session;
            query = query.OrderBy(p => p.Id);
            //IQueryable<Session> query = _context.Session;
            //query = query
            //    .OrderBy(p => p.Id)
            //    //.Where(p => p.Area.ToLower()
            //    .Contains(Area.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Session[]> GetAllFreelas()
        {
            IQueryable<Session> query = _context.Session;
            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Session> GetFreelaByIdAsync(int Id)
        {
            IQueryable<Session> query = _context.Session;
            query = query.OrderBy(p => p.Id).Where(p => p.Id == Id);

            return await query.FirstOrDefaultAsync();
        }

    }
}
