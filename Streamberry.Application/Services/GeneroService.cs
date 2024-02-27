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

        public async Task<List<Genero>> GetWithFilmesByDate(int initial, int final)
        {
            var generos = await _generoRepository.GetAll();
            var result = generos.ToList();
            foreach (var genero in result)
            {
                genero.Filmes = genero.Filmes.Where(f => f.AnoLancamento >= initial && f.AnoLancamento <= final).ToList();
            }
            return result;
        }
    }
}