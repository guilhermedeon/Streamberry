namespace Streamberry.Domain.Entities
{
    public partial class Streaming : BaseEntity
    {
        public string Nome { get; set; } = null!;

        public virtual ICollection<Filme> Filmes { get; set; } = new List<Filme>();
    }
}