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
    public class FilmesController2 : ControllerBase
    {
        private readonly FilmeService _filmeService;

        public FilmesController2(FilmeService filmeService)
        {
            _filmeService = filmeService;
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
    }
}

