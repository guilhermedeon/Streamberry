using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Streamberry.Domain.Entities;

public class Avaliacao
{
    [Key]
    public int? Id { get; set; }

    public int? Classificacao { get; set; }

    public string? Comentario { get; set; }

    [ForeignKey("Filme")]
    public int? FilmeId { get; set; }

    [ForeignKey("Usuario")]
    public int? UsuarioId { get; set; }

    public virtual Filme? Filme { get; set; }

    public virtual Usuario? Usuario { get; set; }
}