using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streamberry.Application.Services;
using Streamberry.Domain.Entities;
using Streamberry.WebAPI.DTO.StreamingDTO;

namespace Streamberry.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StreamingsController : ControllerBase
    {
        private readonly StreamingService _streamingService;
        private readonly FilmeService _filmeService;

        public StreamingsController(StreamingService streamingService)
        {
            _streamingService = streamingService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<StreamingResponseDTO>> GetAll()
        {
            var result = new List<StreamingResponseDTO>();
            var streamings = await _streamingService.GetAll();
            foreach (var streaming in streamings)
            {
                result.Add(new StreamingResponseDTO(streaming));
            }
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<StreamingResponseDTO>> GetById(int id)
        {
            var streaming = await _streamingService.GetById(id);
            if (streaming == null)
            {
                return NotFound();
            }
            return Ok(new StreamingResponseDTO(streaming));
        }

        [HttpGet("GetByName")]
        public async Task<ActionResult<StreamingResponseDTO>> GetByName(string name)
        {
            var streaming = await _streamingService.GetByName(name);
            if (streaming == null)
            {
                return NotFound();
            }
            return Ok(new StreamingResponseDTO(streaming));
        }

        [HttpPost("Add")]
        public async Task<ActionResult<StreamingResponseDTO>> Add(StreamingRequestDTO streamingRequestDTO)
        {
            var streaming = new Streaming() { Nome = streamingRequestDTO.Nome };
            _streamingService.Add(streaming);
            return CreatedAtAction("GetStreaming", streaming.Id, new StreamingResponseDTO(streaming));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<StreamingResponseDTO>> Update(int id, StreamingRequestDTO streamingRequestDTO)
        {
            var streaming = await _streamingService.GetById(id);
            if (streaming == null)
            {
                return NotFound();
            }
            streaming.Nome = streamingRequestDTO.Nome;
            _streamingService.Update(streaming);
            return CreatedAtAction("GetStreaming", id, new StreamingResponseDTO(streaming));
        }

        [HttpPut("AddFilme")]
        public async Task<ActionResult<StreamingResponseDTO>> AddFilme(int id, int idFilme)
        {
            var streaming = await _streamingService.GetById(id);
            if (streaming == null)
            {
                return NotFound();
            }
            var filme = await _filmeService.GetById(idFilme);
            if (filme == null)
            {
                return NotFound();
            }
            streaming.Filmes.Add(filme);
            _streamingService.Update(streaming);
            return CreatedAtAction("GetStreaming", id, new StreamingResponseDTO(streaming));
        }

        [HttpPut("RemoveFilme")]
        public async Task<ActionResult<StreamingResponseDTO>> RemoveFilme(int id, int idFilme)
        {
            var streaming = await _streamingService.GetById(id);
            if (streaming == null)
            {
                return NotFound();
            }
            var filme = await _filmeService.GetById(idFilme);
            if (filme == null)
            {
                return NotFound();
            }
            streaming.Filmes.Remove(filme);
            _streamingService.Update(streaming);
            return CreatedAtAction("GetStreaming", id, new StreamingResponseDTO(streaming));
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var streaming = await _streamingService.GetById(id);
            if (streaming == null)
            {
                return NotFound();
            }
            _streamingService.Remove(streaming);
            return NoContent();
        }
    }
}
