using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using connectWeek.App.Interfaces;
using connectWeek.App.Dtos.Desafio;

namespace ConnectWeek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesafiosController : ControllerBase
    {
        private readonly IDesafioService _desafioService;

        public DesafiosController(IDesafioService desafioService)
        {
            _desafioService = desafioService;
        }

        /// <summary>
        /// Cria um novo desafio
        /// </summary>
        /// <param name="criaDesafioDto">Dados para criação do desafio</param>
        /// <returns>Desafio criado com sucesso</returns>
        /// <response code="201">Desafio criado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="401">Não autorizado</response>
        [HttpPost("criarDesafio")]
        public async Task<ActionResult<CriaDesafioDto>> CriarDesafioAsync(CriaDesafioDto criaDesafioDto, Guid idUsuario)
        {
            try
            {
                var desafio = await _desafioService.CriarDesafioAsync(criaDesafioDto, idUsuario);
                return Ok(desafio);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao criar desafio", details = ex.Message });
            }
        }

    }
}
