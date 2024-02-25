using Streamberry.Domain.Abstractions;
using Streamberry.Domain.Entities;

namespace Streamberry.Application.Services
{
    public class FilmeService : BaseService<IFilmeRepository, Filme>
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository) : base(filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<Filme> GetByTitle(string nome)
        {
            var result = await _filmeRepository.GetAll();
            return result.FirstOrDefault(f => f.Titulo == nome);
        }
    }
}