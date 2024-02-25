using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streamberry.Application.Services;
using Streamberry.Domain.DTOs;
using Streamberry.Domain.Entities;

namespace Streamberry.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AvaliacoesController : ControllerBase
    {
        private readonly AvaliacaoService _avaliacaoService;
        private readonly UsuarioService _usuarioService;

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

        [HttpPost("Add")]
        public async Task<ActionResult<AvaliacaoResponseDTO>> Add(AvaliacaoRequestDTO avaliacaoRequestDTO)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var user = await _usuarioService.GetUserFromJWT(token);
            if (user == null)
            {
                return Unauthorized();
            }
            var avaliacaoDb = await _avaliacaoService.GetByUsuarioIdAndFilmeId(user.Id, avaliacaoRequestDTO.IdFilme);
            if (avaliacaoDb != null)
            {
                return BadRequest("Usuário já avaliou este filme");
            }
            var avaliacao = new Avaliacao() { Classificacao = avaliacaoRequestDTO.Classificacao, Comentario = avaliacaoRequestDTO.Comentario, IdFilme = avaliacaoRequestDTO.IdFilme, IdUsuario = user.Id};
            _avaliacaoService.Add(avaliacao);
            return CreatedAtAction("GetAvaliacao", avaliacao.Id, new AvaliacaoResponseDTO(avaliacao));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<AvaliacaoResponseDTO>> Update(AvaliacaoRequestDTO avaliacaoRequestDTO)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var user = await _usuarioService.GetUserFromJWT(token);
            if (user == null)
            {
                return Unauthorized();
            }
            var avaliacao = await _avaliacaoService.GetByUsuarioIdAndFilmeId(user.Id, avaliacaoRequestDTO.IdFilme);
            if (avaliacao == null)
            {
                return NotFound();
            }
            avaliacao.Classificacao = avaliacaoRequestDTO.Classificacao;
            avaliacao.Comentario = avaliacaoRequestDTO.Comentario;
            _avaliacaoService.Update(avaliacao);
            return CreatedAtAction("GetAvaliacao", avaliacao.Id, new AvaliacaoResponseDTO(avaliacao));
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int idFilme)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var user = await _usuarioService.GetUserFromJWT(token);
            var avaliacao = await _avaliacaoService.GetByUsuarioIdAndFilmeId(user.Id,idFilme);
            if (avaliacao == null)
            {
                return NotFound();
            }
            _avaliacaoService.Remove(avaliacao);
            return NoContent();
        }
    }
}
