using Microsoft.EntityFrameworkCore;
using Streamberry.Domain.Entities;

namespace Streamberry.Interfaces.Database
{
    public interface IStreamberryContext
    {
        DbSet<Avaliacao> Avaliacaoes { get; set; }
        DbSet<Filme> Filmes { get; set; }
        DbSet<Genero> Generos { get; set; }
        DbSet<Streaming> Streamings { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
    }
}