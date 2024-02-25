using Streamberry.Domain.Abstractions;
using Streamberry.Domain.Entities;

namespace Streamberry.Application.Services
{
    public class StreamingService : BaseService<IStreamingRepository, Streaming>
    {
        private readonly IStreamingRepository _steamingRepository;

        public StreamingService(IStreamingRepository repository) : base(repository)
        {
            _steamingRepository = repository;
        }

        public async Task<Streaming> GetByName(string name)
        {
            var result = await _steamingRepository.GetAll();
            return result.FirstOrDefault(s => s.Nome == name);
        }
    }
}