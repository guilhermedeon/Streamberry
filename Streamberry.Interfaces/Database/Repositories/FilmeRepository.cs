using Streamberry.Domain.Abstractions;
using Streamberry.Interfaces.Database;

namespace Streamberry.Interfaces.Database.Repositories
{
    internal class FilmeRepository : IFilmeRepository
    {
        private IStreamberryContext _context;

        public FilmeRepository(IStreamberryContext context)
        {
            _context = context;
        }
    }
}