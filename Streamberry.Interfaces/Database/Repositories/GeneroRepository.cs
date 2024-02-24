using Microsoft.EntityFrameworkCore;
using Streamberry.Domain.Abstractions;
using Streamberry.Domain.Entities;
using Streamberry.Interfaces.Database;

namespace Streamberry.Interfaces.Database.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private IStreamberryContext _context;

        public GeneroRepository(IStreamberryContext context)
        {
            _context = context;
        }

        public void Add(Genero entity)
        {
            _context.Generos.Add(entity);
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Genero>> GetAll()
        {
            return await _context.Generos.Include(x => x.Filmes).ToListAsync();
        }

        public async Task<Genero> GetById(int id)
        {
            return await _context.Generos.Include(x => x.Filmes).FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Genero entity)
        {
            _context.Generos.Remove(entity);
            _context.SaveChangesAsync();
        }

        public void Update(Genero entity)
        {
            _context.Generos.Update(entity);
            _context.SaveChangesAsync();
        }
    }
}