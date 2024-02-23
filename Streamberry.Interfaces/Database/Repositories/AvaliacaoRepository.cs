using Streamberry.Domain.Abstractions;
using Streamberry.Interfaces.Database;

namespace Streamberry.Interfaces.Database.Repositories
{
    internal class AvaliacaoRepository : IAvaliacaoRepository
    {
        private IStreamberryContext _context;

        public AvaliacaoRepository(IStreamberryContext context)
        {
            _context = context;
        }
    }
}