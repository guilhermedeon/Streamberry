using Microsoft.AspNetCore.Mvc;
using Streamberry.Application.Services;
using Streamberry.Domain.DTOs;

namespace Streamberry.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacoesController : ControllerBase
    {
        private readonly AvaliacaoService _avaliacaoService;

        public AvaliacoesController(AvaliacaoService avaliacaoService)
        {
            _avaliacaoService = avaliacaoService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<AvaliacaoResponseDTO>>> GetAll()
        {
            var result = new List<AvaliacaoResponseDTO>();
            var avaliacoes = await _avaliacaoService.GetAll();
            foreach (var avaliacao in avaliacoes)
            {
                result.Add(new AvaliacaoResponseDTO(avaliacao));
            }
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<AvaliacaoResponseDTO>> GetById(int id)
        {
            var avaliacao = await _avaliacaoService.GetById(id);
            if (avaliacao == null)
            {
                return NotFound();
            }
            return Ok(new AvaliacaoResponseDTO(avaliacao));
        }

        [HttpGet("GetByUsuarioId")]
        public async Task<ActionResult<IEnumerable<AvaliacaoResponseDTO>>> GetByUsuarioId(int id)
        {
            var result = new List<AvaliacaoResponseDTO>();
            var avaliacoes = await _avaliacaoService.GetAll();
            avaliacoes = avaliacoes.Where(x => x.IdUsuario == id);
            foreach (var avaliacao in avaliacoes)
            {
                result.Add(new AvaliacaoResponseDTO(avaliacao));
            }
            return Ok(result);
        }

        [HttpGet("GetByFilmeId")]
        public async Task<ActionResult<IEnumerable<AvaliacaoResponseDTO>>> GetByFilmeId(int id)
        {
            var result = new List<AvaliacaoResponseDTO>();
            var avaliacoes = await _avaliacaoService.GetAll();
            avaliacoes = avaliacoes.Where(x => x.IdFilme == id);
            foreach (var avaliacao in avaliacoes)
            {
                result.Add(new AvaliacaoResponseDTO(avaliacao));
            }
            return Ok(result);
        }

        //TODO POST, PUT, DELETE


    }
}
