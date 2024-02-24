using System;
using System.Collections.Generic;

namespace Streamberry.Domain.Entities;

public partial class Avaliacao
{
    public int Id { get; set; }

    public int? Classificacao { get; set; }

    public string? Comentario { get; set; }

    public int? IdFilme { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Filme? Filme { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
