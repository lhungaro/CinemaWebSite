using Freela.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freela.Persistence.Repository
{
    public interface ISessionRepository
    {
        Task<Session> GetFreelaByIdAsync(int Id);
        Task<Session[]> GetAllFreelas();
        Task<Session[]> GetAllFreelaByAreaAsync(string Area);
    }
}
