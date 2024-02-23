using Streamberry.Domain.Abstractions;
using Streamberry.Interfaces.Database;

namespace Streamberry.Interfaces.Database.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private IStreamberryContext _context;

        public UsuarioRepository(IStreamberryContext context)
        {
            _context = context;
        }
    }
}