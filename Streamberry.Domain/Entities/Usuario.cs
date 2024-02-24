using System;
using System.Collections.Generic;

namespace Streamberry.Domain.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public virtual ICollection<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
}
