using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streamberry.Application.Services;
using Streamberry.WebAPI.DTO.FilmeDTO;
using Streamberry.WebAPI.DTO.GeneroDTO;
using Streamberry.WebAPI.DTO.UsuarioDTO;

namespace Streamberry.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AIOController : ControllerBase
    {
        private readonly AvaliacaoService _avaliacaoService;
        private readonly FilmeService _filmeService;
        private readonly GeneroService _generoService;
        private readonly StreamingService _streamingService;
        private readonly UsuarioService _usuarioService;

        public AIOController(AvaliacaoService avaliacaoService, FilmeService filmeService, GeneroService generoService, StreamingService streamingService, UsuarioService usuarioService)
        {
            _avaliacaoService = avaliacaoService;
            _filmeService = filmeService;
            _generoService = generoService;
            _streamingService = streamingService;
            _usuarioService = usuarioService;
        }

        [HttpPost("LoginPreset")]
        public async Task<ActionResult<string>> Login()
        {
            var token = await _usuarioService.Authenticate("user@example.com", "string");

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }

        [HttpGet("1_2_PegarTodosOsFilmesDetalhado")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<FilmeResponseDTO>>> GetAllFilmes(bool paging, int? pageNumber, int? pageSize)
        {
            var filmesDb = await _filmeService.GetAll();
            var filmes = filmesDb;
            if (paging && pageNumber != null && pageSize != null)
            {
                filmes = filmesDb.Skip((int)((pageNumber - 1) * pageSize)).Take((int)pageSize);
            }

            var result = new List<FilmeResponseDTO>();
            foreach (var filme in filmes)
            {
                result.Add(new FilmeResponseDTO(filme));
            }
            return Ok(result);
        }

        [HttpGet("3_LocalizarFilmesPorAnoDeLancamento")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<FilmesByYearResponse>>> GetFilmeByYear(int ano)
        {
            var filmes = await _filmeService.GetAll();
            var result = new FilmesByYearResponse();
            result.Filmes = new List<FilmeResponseDTO>();
            foreach (var filme in filmes)
            {
                if (filme.AnoLancamento == ano)
                {
                    result.Filmes.Add(new FilmeResponseDTO(filme));
                }
            }
            result.Ammount = result.Filmes.Count;
            return Ok(result);
        }

        [HttpGet("4_LocalizarFilmesPorAvaliacao")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<FilmesByRankResponse>>> GetFilmesByRank(int rank)
        {
            var filmes = await _filmeService.GetAll();
            List<FilmeResponseDTO> filmeResponseDTOs = new List<FilmeResponseDTO>();
            foreach (var filme in filmes)
            {
                filmeResponseDTOs.Add(new FilmeResponseDTO(filme));
            }
            filmeResponseDTOs = filmeResponseDTOs.Where(x => x.MediaAvaliacao == rank).ToList();

            var result = new FilmesByRankResponse();
            result.Classificacao = rank;
            result.Filmes = filmeResponseDTOs;
            return Ok(result);
        }

        [HttpGet("5_BuscarPorDataComRetornoAgrupadoPorGenero")]
        [Authorize]
        public async Task<ActionResult<GeneroMediaByYearResponse>> GetGeneroByDate(int initial, int final)
        {
            var generos = await _generoService.GetWithFilmesByDate(initial, final);
            var result = new GeneroMediaByYearResponse()
            {
                InitialYear = initial,
                FinalYear = final
            };
            foreach (var genero in generos)
            {
                result.Generos.Add(new GeneroResponseDTO(genero));
            }
            return Ok(result);
        }

    }
}