using System;
using System.Collections.Generic;

namespace Streamberry.Domain.Entities;

public partial class Streaming
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Filme> IdFilmes { get; set; } = new List<Filme>();
}
