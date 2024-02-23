using Streamberry.Domain.Abstractions;
using Streamberry.Interfaces.Database;

namespace Streamberry.Interfaces.Database.Repositories
{
    internal class GeneroRepository : IGeneroRepository
    {
        private IStreamberryContext _context;

        public GeneroRepository(IStreamberryContext context)
        {
            _context = context;
        }
    }
}