using Streamberry.Domain.Abstractions;
using Streamberry.Domain.Entities;

namespace Streamberry.Application.Services
{
    public class AvaliacaoService : BaseService<IAvaliacaoRepository, Avaliacao>
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoService(IAvaliacaoRepository repository) : base(repository)
        {
            _avaliacaoRepository = repository;
        }

        public async Task<Avaliacao> GetByUsuarioIdAndFilmeId(int id, int idFilme)
        {
            var all = await _avaliacaoRepository.GetAll();
            return all.FirstOrDefault(x => x.IdUsuario == id && x.IdFilme == idFilme);
        }
    }
}