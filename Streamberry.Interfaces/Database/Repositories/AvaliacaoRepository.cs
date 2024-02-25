using Microsoft.EntityFrameworkCore;
using Streamberry.Domain.Abstractions;
using Streamberry.Domain.Entities;

namespace Streamberry.Interfaces.Database.Repositories
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly IStreamberryContext _context;

        public AvaliacaoRepository(IStreamberryContext context)
        {
            _context = context;
        }

        public void Add(Avaliacao entity)
        {
            _context.Avaliacoes.Add(entity);
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Avaliacao>> GetAll()
        {
            return await _context.Avaliacoes.Include(t => t.Usuario).Include(t => t.Filme).ToListAsync();
        }

        public async Task<Avaliacao> GetById(int id)
        {
            return await _context.Avaliacoes.Include(t => t.Usuario).Include(t => t.Filme).FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Avaliacao entity)
        {
            _context.Avaliacoes.Remove(entity);
            _context.SaveChangesAsync();
        }

        public void Update(Avaliacao entity)
        {
            _context.Avaliacoes.Update(entity);
            _context.SaveChangesAsync();
        }
    }
}