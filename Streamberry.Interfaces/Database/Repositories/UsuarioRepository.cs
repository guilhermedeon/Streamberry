using Microsoft.EntityFrameworkCore;
using Streamberry.Domain.Abstractions;
using Streamberry.Domain.Entities;
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

        public void Add(Usuario entity)
        {
            _context.Usuarios.Add(entity);
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _context.Usuarios.Include(t => t.Avaliacoes).ToListAsync();
        }

        public async Task<Usuario> GetById(int id)
        {
            return await _context.Usuarios.Include(t => t.Avaliacoes).FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Usuario entity)
        {
            _context.Usuarios.Remove(entity);
            _context.SaveChangesAsync();
        }

        public void Update(Usuario entity)
        {
            _context.Usuarios.Update(entity);
            _context.SaveChangesAsync();
        }
    }
}