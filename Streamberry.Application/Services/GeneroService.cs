using Streamberry.Domain.Abstractions;
using Streamberry.Domain.Entities;

namespace Streamberry.Application.Services
{
    public class GeneroService : BaseService<IGeneroRepository, Genero>
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroService(IGeneroRepository repository) : base(repository)
        {
            _generoRepository = repository;
        }

        public async Task<Genero?> GetByName(string nome)
        {
            var result = await _generoRepository.GetAll();
            return result.FirstOrDefault(g => g.Nome == nome);
        }
    }
}