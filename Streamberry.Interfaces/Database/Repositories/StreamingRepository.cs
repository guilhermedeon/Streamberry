using Microsoft.EntityFrameworkCore;
using Streamberry.Domain.Abstractions;
using Streamberry.Domain.Entities;

namespace Streamberry.Interfaces.Database.Repositories
{
    public class StreamingRepository : IStreamingRepository
    {
        private readonly IStreamberryContext _context;

        public StreamingRepository(IStreamberryContext context)
        {
            _context = context;
        }

        public void Add(Streaming entity)
        {
            _context.Streamings.Add(entity);
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Streaming>> GetAll()
        {
            return await _context.Streamings.Include(x => x.Filmes).ToListAsync();
        }

        public async Task<Streaming> GetById(int id)
        {
            return await _context.Streamings.Include(x => x.Filmes).FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Streaming entity)
        {
            _context.Streamings.Remove(entity);
            _context.SaveChangesAsync();
        }

        public void Update(Streaming entity)
        {
            _context.Streamings.Update(entity);
            _context.SaveChangesAsync();
        }
    }
}