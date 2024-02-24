using System;
using System.Collections.Generic;

namespace Streamberry.Domain.Entities;
public partial class Filme
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? MesLancamento { get; set; }

    public int? AnoLancamento { get; set; }

    public virtual ICollection<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();

    public virtual ICollection<Genero> IdGeneros { get; set; } = new List<Genero>();

    public virtual ICollection<Streaming> IdStreamings { get; set; } = new List<Streaming>();
}
