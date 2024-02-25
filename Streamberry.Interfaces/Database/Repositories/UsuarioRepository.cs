using Microsoft.EntityFrameworkCore;
using Streamberry.Domain.Abstractions;
using Streamberry.Domain.Entities;

namespace Streamberry.Interfaces.Database.Repositories
{
    public class UsuarioRepository(IStreamberryContext context) : IUsuarioRepository
    {
        public void Add(Usuario entity)
        {
            context.Usuarios.Add(entity);
            context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await context.Usuarios.Include(t => t.Avaliacoes).ToListAsync();
        }

        public async Task<Usuario> GetById(int id)
        {
            return await context.Usuarios.Include(t => t.Avaliacoes).FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Usuario entity)
        {
            context.Usuarios.Remove(entity);
            context.SaveChangesAsync();
        }

        public void Update(Usuario entity)
        {
            context.Usuarios.Update(entity);
            context.SaveChangesAsync();
        }
    }
}