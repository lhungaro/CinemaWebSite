using Freela.Application.Contratos;
using Freela.Domain.Models;
using Freela.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freela.Application
{
    public class SessionService : ISessionService
    {
        private readonly IFreelaRepository _freelaRepository;
        private readonly ISessionRepository _sessionRepository;

        public SessionService(IFreelaRepository freelaRepository, ISessionRepository sessionRepository)
        {
            _freelaRepository = freelaRepository;
            _sessionRepository = sessionRepository;
        }
        public async Task<Session> AddSession(Session model)
        {
            try
            {
                _freelaRepository.Add<Session>(model);
                if (await _freelaRepository.SaveChangesAsync())
                    return await _sessionRepository.GetFreelaByIdAsync(model.Id);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Session> UpdateSession(int projectId, Session model)
        {
            try
            {
                var project = await _sessionRepository.GetFreelaByIdAsync(projectId);
                if(project == null) return null;

                model.Id = project.Id;

                _freelaRepository.Update(model);

                if (await _freelaRepository.SaveChangesAsync())
                    return await _sessionRepository.GetFreelaByIdAsync(model.Id);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteSession(int projectId)
        {
            try
            {
                var project = await _sessionRepository.GetFreelaByIdAsync(projectId);
                if (project == null) throw new Exception("Projeto não encontrado!");

                _freelaRepository.Delete<Session>(project);

                return await _freelaRepository.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Session[]> GetAllSession()
        {
            try
            {
                var projects = await _sessionRepository.GetAllFreelas();
                if (projects == null) return null;

                return projects;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Session[]> GetAllSessionByAreaAsync(string Area)
        {
            try
            {
                var projects = await _sessionRepository.GetAllFreelaByAreaAsync(Area);
                if (projects == null) return null;

                return projects;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Session> GetSessionByIdAsync(int Id)
        {
            try
            {
                var projects = await _sessionRepository.GetFreelaByIdAsync(Id);
                if (projects == null) return null;

                return projects;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

   
    }
}
