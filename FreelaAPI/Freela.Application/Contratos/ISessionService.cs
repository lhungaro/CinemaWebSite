using Freela.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freela.Application.Contratos
{
    public interface ISessionService
    {
        Task<Session> AddSession(Session model);
        Task<Session> UpdateSession(int projectId, Session model);
        Task <bool> DeleteSession(int projectId);
        Task<Session[]> GetAllSession();
        Task<Session[]> GetAllSessionByAreaAsync(string Area);
        Task<Session> GetSessionByIdAsync(int Id);

    }
}
