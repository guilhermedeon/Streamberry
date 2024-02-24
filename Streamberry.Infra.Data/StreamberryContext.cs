﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Streamberry.Domain.Entities;
using Streamberry.Interfaces.Database;

namespace Streamberry.Infra.Data;

public partial class StreamberryContext : DbContext, IStreamberryContext
{
    public StreamberryContext()
    {
    }

    public StreamberryContext(DbContextOptions<StreamberryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Avaliacao> Avaliacoes { get; set; }

    public virtual DbSet<Filme> Filmes { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Streaming> Streamings { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("DataSource=C:\\Users\\guilh\\Desktop\\Streamberry\\Streamberry\\Streamberry.sqlite3");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Avaliacao>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("id");
            entity.Property(e => e.Classificacao)
                .HasColumnType("INT")
                .HasColumnName("classificacao");
            entity.Property(e => e.Comentario).HasColumnName("comentario");
            entity.Property(e => e.IdFilme)
                .HasColumnType("INT")
                .HasColumnName("id_filme");
            entity.Property(e => e.IdUsuario)
                .HasColumnType("INT")
                .HasColumnName("id_usuario");

            entity.HasOne(d => d.Filme).WithMany(p => p.Avaliacoes).HasForeignKey(d => d.IdFilme);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Avaliacoes).HasForeignKey(d => d.IdUsuario);
        });

        modelBuilder.Entity<Filme>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("id");
            entity.Property(e => e.AnoLancamento)
                .HasColumnType("INT")
                .HasColumnName("ano_lancamento");
            entity.Property(e => e.MesLancamento)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("mes_lancamento");
            entity.Property(e => e.Titulo)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("titulo");

            entity.HasMany(d => d.IdGeneros).WithMany(p => p.IdFilmes)
                .UsingEntity<Dictionary<string, object>>(
                    "FilmesGenero",
                    r => r.HasOne<Genero>().WithMany()
                        .HasForeignKey("IdGenero")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Filme>().WithMany()
                        .HasForeignKey("IdFilme")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("IdFilme", "IdGenero");
                        j.ToTable("FilmesGeneros");
                        j.IndexerProperty<int>("IdFilme")
                            .HasColumnType("INT")
                            .HasColumnName("id_filme");
                        j.IndexerProperty<int>("IdGenero")
                            .HasColumnType("INT")
                            .HasColumnName("id_genero");
                    });

            entity.HasMany(d => d.IdStreamings).WithMany(p => p.IdFilmes)
                .UsingEntity<Dictionary<string, object>>(
                    "FilmesStreaming",
                    r => r.HasOne<Streaming>().WithMany()
                        .HasForeignKey("IdStreaming")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Filme>().WithMany()
                        .HasForeignKey("IdFilme")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("IdFilme", "IdStreaming");
                        j.ToTable("FilmesStreaming");
                        j.IndexerProperty<int>("IdFilme")
                            .HasColumnType("INT")
                            .HasColumnName("id_filme");
                        j.IndexerProperty<int>("IdStreaming")
                            .HasColumnType("INT")
                            .HasColumnName("id_streaming");
                    });
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Streaming>(entity =>
        {
            entity.ToTable("Streaming");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("nome");
            entity.Property(e => e.Senha)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("senha");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
