using System.ComponentModel.DataAnnotations;

namespace Streamberry.Domain.Entities;

public class Genero
{
    [Key]
    public int? Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Filme> Filmes { get; set; } = new List<Filme>();
}