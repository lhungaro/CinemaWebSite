using Freela.Application;
using Freela.Application.Contratos;
using Freela.Domain.Models;
using FreelaAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace Freela_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var sessions = await _sessionService.GetAllSession();
                if (sessions == null) return NotFound("Nenhum projeto encontrado");

                return Ok(sessions);
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
                var sessions = await _sessionService.GetSessionByIdAsync(id);
                if (sessions == null) return NotFound("Nenhum projeto encontrado");

                return Ok(sessions);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar projetos. Erro : {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Session model)
        {
            try
            {
                var sessions = await _sessionService.UpdateSession(id,model);
                if (sessions == null) return BadRequest("Erro ao adicionar o Projeto");

                return Ok(sessions);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar projetos. Erro : {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Session model)
        {
            try
            {
                var sessions = await _sessionService.AddSession(model);
                if (sessions == null) return BadRequest("Erro ao adicionar o Projeto");

                return Ok(sessions);
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
                return await _sessionService.DeleteSession(id) 
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
