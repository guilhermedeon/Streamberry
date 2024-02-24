using Streamberry.Domain.Abstractions;
using Streamberry.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _steamingRepository.GetAll().Result.FirstOrDefault(s => s.Nome == name);
        }
    }
}
