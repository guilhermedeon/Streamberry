using Streamberry.Domain.Abstractions;
using Streamberry.Domain.Entities;

namespace Streamberry.Application.Services
{
    public class AvaliacaoService(IAvaliacaoRepository repository) : BaseService<IAvaliacaoRepository, Avaliacao>(repository)
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository = repository;

        public async Task<Avaliacao> GetByUsuarioIdAndFilmeId(int id, int idFilme)
        {
            var all = await _avaliacaoRepository.GetAll();
            return all.FirstOrDefault(x => x.IdUsuario == id && x.IdFilme == idFilme);
        }
    }
}