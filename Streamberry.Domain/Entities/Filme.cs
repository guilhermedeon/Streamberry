namespace Streamberry.Domain.Entities
{
    public partial class Filme : BaseEntity
    {
        public string Titulo { get; set; } = null!;

        public string MesLancamento { get; set; }

        public int AnoLancamento { get; set; }

        public virtual ICollection<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();

        public virtual ICollection<Genero> Generos { get; set; } = new List<Genero>();

        public virtual ICollection<Streaming> Streamings { get; set; } = new List<Streaming>();
    }
}