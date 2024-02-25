using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Streamberry.Application.Services;
using Streamberry.Domain.DTOs;
using Streamberry.Domain.Entities;
using Streamberry.Infra.Data;

namespace Streamberry.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenerosController : ControllerBase
    {
        private readonly GeneroService _generoService;
        private readonly FilmeService _filmeService;

        public GenerosController(GeneroService generoService, FilmeService filmeService)
        {
            _generoService = generoService;
            _filmeService = filmeService;
        }


        [HttpGet("GetAllGeneros")]
        public async Task<ActionResult<IEnumerable<GeneroResponseDTO>>> GetAllGeneros()
        {
            var result = new List<GeneroResponseDTO>();
            var generos = await _generoService.GetAll();
            foreach (var genero in generos)
            {
                result.Add(new GeneroResponseDTO(genero));
            }
            return Ok(result);
        }

        [HttpGet("GetGeneroById")]
        public async Task<ActionResult<GeneroResponseDTO>> GetGeneroById(int id)
        {
            var genero = await _generoService.GetById(id);
            if (genero == null)
            {
                return NotFound();
            }
            var response = new GeneroResponseDTO(genero);
            return Ok(response);
        }

        [HttpGet("GetGeneroByName")]
        public async Task<ActionResult<GeneroResponseDTO>> GetGeneroByName(string nome)
        {
            var genero = _generoService.GetByName(nome);
            if (genero == null)
            {
                return NotFound();
            }
            var response = new GeneroResponseDTO(genero);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<GeneroResponseDTO>> PostGenero(GeneroRequestDTO generoRequest)
        {
            if (_generoService.GetByName(generoRequest.Nome) != null)
            {
                return Conflict();
            }
            else
            {
                Genero genero = new Genero();
                genero.Nome = generoRequest.Nome;
                _generoService.Add(genero);

                return CreatedAtAction("GetGenero", genero.Id, genero);
            }
        }

        [HttpPut]
        public async Task<ActionResult<GeneroResponseDTO>> UpdateGenero(int id, GeneroRequestDTO generoRequest)
        {
            var genero = await _generoService.GetById(id);
            if (genero == null)
            {
                return NotFound();
            }
            else
            {
                genero.Nome = generoRequest.Nome;
                _generoService.Update(genero);
                return CreatedAtAction("GetGenero", genero.Id, genero);
            }
        }

        [HttpPut("AddFilme")]
        public async Task<ActionResult<GeneroResponseDTO>> AddFilme(int id, int filmeId)
        {
            var genero = await _generoService.GetById(id);
            var filme = await _filmeService.GetById(filmeId);
            if (genero == null || filme == null)
            {
                return NotFound();
            }
            else
            {
                genero.Filmes.Add(filme);
                _generoService.Update(genero);
                return CreatedAtAction("GetFilmeById", filme.Id, filme);
            }
        }

        [HttpPut("RemoveFilme")]
        public async Task<ActionResult> RemoveFilme(int id, int filmeId)
        {
            var genero = await _generoService.GetById(id);
            var filme = await _filmeService.GetById(filmeId);
            if (genero == null || filme == null)
            {
                return NotFound();
            }
            else
            {
                genero.Filmes.Remove(filme);
                _generoService.Update(genero);
                return CreatedAtAction("GetFilmeById", filme.Id, filme);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteGenero(int id)
        {
            var genero = await _generoService.GetById(id);
            if (genero == null)
            {
                return NotFound();
            }
            else
            {
                _generoService.Remove(genero);
                return NoContent();
            }
        }
    }
}

