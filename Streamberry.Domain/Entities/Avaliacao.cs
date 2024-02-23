using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Streamberry.Domain.Entities;

public partial class Avaliacao
{
    [Key]
    public int? Id { get; set; }

    public int? FilmeId { get; set; }

    public int? UsuarioId { get; set; }

    public int? Classificacao { get; set; }

    public string? Comentario { get; set; }

    public virtual Filme? Filme { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
