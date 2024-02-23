using Streamberry.Domain.Abstractions;
using Streamberry.Interfaces.Database;

namespace Streamberry.Interfaces.Database.Repositories
{
    internal class StreamingRepository : IStreamingRepository
    {
        private IStreamberryContext _context;

        public StreamingRepository(IStreamberryContext context)
        {
            _context = context;
        }
    }
}