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
    public class GenerosController : ControllerBase
    {
        private readonly GeneroService _generoService;

        public GenerosController(GeneroService generoService)
        {
            _generoService = generoService;
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

        [HttpGet("GetGenero")]
        public async Task<ActionResult<Genero>> GetGenero(int id)
        {
            var genero = await _generoService.GetById(id);
            if (genero == null)
            {
                return NotFound();
            }
            var response = new GeneroResponseDTO(genero);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Genero>> PostGenero(GeneroRequestDTO generoRequest)
        {
            if (_generoService.GetByName(generoRequest.Nome) != null)
            {
                return Conflict();
            }
            else
            {
                Genero Genero = new Genero();
                Genero.Nome = generoRequest.Nome;
                _generoService.Add(Genero);

                return CreatedAtAction("GetGenero", Genero.Id, Genero);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Genero>> PutGenero(int id, GeneroRequestDTO generoRequest)
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
                return NoContent();
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Genero>> DeleteGenero(int id)
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

