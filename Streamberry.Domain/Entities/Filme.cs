using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Streamberry.Domain.Entities;

public class Filme
{
    [Key]
    public int? Id { get; set; }

    public string Titulo { get; set; } = null!;

    public int? MesLancamento { get; set; }

    public int? AnoLancamento { get; set; }

    public virtual ICollection<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();

    [ForeignKey("Genero")]
    public int? GeneroId { get; set; }

    public virtual Genero? Genero { get; set; }
}