using Microsoft.EntityFrameworkCore;
using Streamberry.Domain.Entities;
using Streamberry.Interfaces.Database;

namespace Streamberry.Infra.Data.Models;

public class StreamberryContext : DbContext, IStreamberryContext
{
    public StreamberryContext()
    {
    }

    public StreamberryContext(DbContextOptions<StreamberryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Avaliacao> Avaliacaoes { get; set; }

    public virtual DbSet<Filme> Filmes { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Streaming> Streamings { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }
    /*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\guilh\\Desktop\\Streamberry\\Streamberry\\Streamberry.sqlite3");
    */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Avaliacao>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Classificacao).HasColumnName("classificacao");
            entity.Property(e => e.Comentario).HasColumnName("comentario");
            entity.Property(e => e.FilmeId).HasColumnName("filme_id");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Filme).WithMany(p => p.Avaliacoes).HasForeignKey(d => d.FilmeId);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Avaliacoes).HasForeignKey(d => d.UsuarioId);
        });

        modelBuilder.Entity<Filme>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.AnoLancamento).HasColumnName("ano_lancamento");
            entity.Property(e => e.GeneroId).HasColumnName("genero_id");
            entity.Property(e => e.MesLancamento).HasColumnName("mes_lancamento");
            entity.Property(e => e.Titulo).HasColumnName("titulo");

            entity.HasOne(d => d.Genero).WithMany(p => p.Filmes).HasForeignKey(d => d.GeneroId);
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Nome).HasColumnName("nome");
        });

        modelBuilder.Entity<Streaming>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Nome).HasColumnName("nome");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Nome).HasColumnName("nome");
            entity.Property(e => e.Senha).HasColumnName("senha");
        });
    }
}