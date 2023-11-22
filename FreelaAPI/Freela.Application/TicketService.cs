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
    public class TicketService : ITicketService
    {
        private readonly IFreelaRepository _freelaRepository;
        private readonly ITicketRepository _ticketRepository;

        public TicketService(IFreelaRepository freelaRepository, ITicketRepository ticketRepository)
        {
            _freelaRepository = freelaRepository;
            _ticketRepository = ticketRepository;
        }
        public async Task<Ticket> AddTicket(Ticket model)
        {
            try
            {
                _freelaRepository.Add<Ticket>(model);
                if (await _freelaRepository.SaveChangesAsync())
                    return await _ticketRepository.GetTicketByIdAsync(model.Id);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Ticket> UpdateTicket(int ticketId, Ticket model)
        {
            try
            {
                var ticket = await _ticketRepository.GetTicketByIdAsync(ticketId);
                if(ticket == null) return null;

                model.Id = ticket.Id;

                _freelaRepository.Update(model);

                if (await _freelaRepository.SaveChangesAsync())
                    return await _ticketRepository.GetTicketByIdAsync(model.Id);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteTicket(int ticketId)
        {
            try
            {
                var ticket = await _ticketRepository.GetTicketByIdAsync(ticketId);
                if (ticket == null) throw new Exception("Projeto não encontrado!");

                _freelaRepository.Delete<Ticket>(ticket);

                return await _freelaRepository.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Ticket[]> GetAllTickets()
        {
            try
            {
                var tickets = await _ticketRepository.GetAllTickets();
                if (tickets == null) return null;

                return tickets;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Ticket[]> GetAllTicketsBySessionAsync(int sessionId)
        {
            try
            {
                var tickets = await _ticketRepository.GetAllTicketsBySessionAsync(sessionId);
                if (tickets == null) return null;

                return tickets;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Ticket> GetTicketByIdAsync(int Id)
        {
            try
            {
                var tickets = await _ticketRepository.GetTicketByIdAsync(Id);
                if (tickets == null) return null;

                return tickets;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

   
    }
}
