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
    public class FilmesController : ControllerBase
    {
        private readonly FilmeService _filmeService;
        private readonly GeneroService _generoService;
        private readonly StreamingService streamingService;

        public FilmesController(FilmeService filmeService, GeneroService generoService, StreamingService streamingService)
        {
            _filmeService = filmeService;
            _generoService = generoService;
            this.streamingService = streamingService;
        }

        // GET: api/Filmes
        [HttpGet("GetAllFilmes")]
        public async Task<ActionResult<IEnumerable<Filme>>> GetAllFilmes()
        {
            var filmes = await _filmeService.GetAll();
            var result = new List<FilmeResponseDTO>();
            foreach (var filme in filmes)
            {
                result.Add(new FilmeResponseDTO(filme));
            }
            return Ok(result);
        }

        [HttpGet("GetFilmeById")]
        public async Task<ActionResult<Filme>> GetFilmeById(int id)
        {
            var filme = await _filmeService.GetById(id);
            if (filme == null)
            {
                return NotFound();
            }
            var result = new FilmeResponseDTO(filme);
            return Ok(result);
        }

        [HttpGet("GetFilmeByTitle")]
        public async Task<ActionResult<Filme>> GetFilmeByTitle(string titulo)
        {
            var filme = _filmeService.GetByTitle(titulo);
            if (filme == null)
            {
                return NotFound();
            }
            var result = new FilmeResponseDTO(filme);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Filme>> PostFilme(FilmeRequestDTO filme)
        {
            if (_filmeService.GetByTitle(filme.Titulo) != null)
            {
                return Conflict();
            }
            var filmeEntity = new Filme()
            {
                Titulo = filme.Titulo,
                AnoLancamento = filme.AnoLancamento,
                MesLancamento = filme.MesLancamento
            };
            _filmeService.Add(filmeEntity);
            return CreatedAtAction("GetFilmeById", filmeEntity.Id , filmeEntity);
        }

        [HttpPut]
        public async Task<IActionResult> PutFilme(int id, FilmeRequestDTO filme)
        {
            var filmeEntity = await _filmeService.GetById(id);
            if (filmeEntity == null)
            {
                return NotFound();
            }
            filmeEntity.Titulo = filme.Titulo;
            filmeEntity.AnoLancamento = filme.AnoLancamento;
            filmeEntity.MesLancamento = filme.MesLancamento;
            _filmeService.Update(filmeEntity);
            return NoContent();
        }

        [HttpPut("AddGenero")]
        public async Task<IActionResult> AddGenero(int id, int generoId)
        {
            var filme = await _filmeService.GetById(id);
            var genero = await _generoService.GetById(generoId);
            if (filme == null || genero == null)
            {
                return NotFound();
            }
            filme.Generos.Add(genero);
            _filmeService.Update(filme);
            return NoContent();
        }

        [HttpPut("RemoveGenero")]
        public async Task<IActionResult> RemoveGenero(int id, int generoId)
        {
            var filme = await _filmeService.GetById(id);
            var genero = await _generoService.GetById(generoId);
            if (filme == null || genero == null)
            {
                return NotFound();
            }
            filme.Generos.Remove(genero);
            _filmeService.Update(filme);
            return NoContent();
        }

        [HttpPut("AddStreaming")]
        public async Task<IActionResult> AddStreaming(int id, int streamingId)
        {
            var filme = await _filmeService.GetById(id);
            var streaming = await streamingService.GetById(streamingId);
            if (filme == null || streaming == null)
            {
                return NotFound();
            }
            filme.Streamings.Add(streaming);
            _filmeService.Update(filme);
            return NoContent();
        }

        [HttpPut("RemoveStreaming")]
        public async Task<IActionResult> RemoveStreaming(int id, int streamingId)
        {
            var filme = await _filmeService.GetById(id);
            var streaming = await streamingService.GetById(streamingId);
            if (filme == null || streaming == null)
            {
                return NotFound();
            }
            filme.Streamings.Remove(streaming);
            _filmeService.Update(filme);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<Filme>> DeleteFilme(int id)
        {
            var filme = await _filmeService.GetById(id);
            if (filme == null)
            {
                return NotFound();
            }
            _filmeService.Remove(filme);
            return filme;
        }
    }
}

