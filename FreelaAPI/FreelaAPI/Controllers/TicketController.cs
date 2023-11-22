using Freela.Application.Contratos;
using Freela.Domain.Models;
using FreelaAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace Freela_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var tickets = await _ticketService.GetAllTickets();
                if (tickets == null) return NotFound("Nenhum projeto encontrado");

                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar projetos. Erro : {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)

        {
            try
            {
                var tickets = await _ticketService.GetTicketByIdAsync(id);
                if (tickets == null) return NotFound("Nenhum projeto encontrado");

                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar projetos. Erro : {ex.Message}");
            }
        }


        [HttpGet("{sessionId}/sessionId")]
        public async Task<IActionResult> GetBySession(int sessionId)

        {
            try
            {
                var tickets = await _ticketService.GetAllTicketsBySessionAsync(sessionId);
                if (tickets == null) return NotFound("Nenhum projeto encontrado");

                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar projetos. Erro : {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Ticket model)
        {
            try
            {
                var tickets = await _ticketService.UpdateTicket(id,model);
                if (tickets == null) return BadRequest("Erro ao adicionar o Projeto");

                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar projetos. Erro : {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Ticket model)
        {
            try
            {
                var tickets = await _ticketService.AddTicket(model);
                if (tickets == null) return BadRequest("Erro ao adicionar o Projeto");

                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar projetos. Erro : {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _ticketService.DeleteTicket(id) 
                    ? Ok() 
                    : BadRequest();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deleta o projeto. Erro : {ex.Message}");
            }
        }
    }
}
