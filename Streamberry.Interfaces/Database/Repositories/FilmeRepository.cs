using Microsoft.EntityFrameworkCore;
using Streamberry.Domain.Abstractions;
using Streamberry.Domain.Entities;

namespace Streamberry.Interfaces.Database.Repositories
{
    public class FilmeRepository(IStreamberryContext context) : IFilmeRepository
    {
        private readonly IStreamberryContext _context = context;

        public void Add(Filme entity)
        {
            _context.Filmes.Add(entity);
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Filme>> GetAll()
        {
            return await _context.Filmes.Include(t => t.Generos).Include(t => t.Streamings).Include(t => t.Avaliacoes).ToListAsync();
        }

        public async Task<Filme> GetById(int id)
        {
            return await _context.Filmes.Include(t => t.Generos).Include(t => t.Streamings).Include(t => t.Avaliacoes).FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Filme entity)
        {
            _context.Filmes.Remove(entity);
            _context.SaveChangesAsync();
        }

        public void Update(Filme entity)
        {
            _context.Filmes.Update(entity);
            _context.SaveChangesAsync();
        }
    }
}