namespace Streamberry.Domain.Entities
{
    public partial class Usuario : BaseEntity
    {
        public string Nome { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Senha { get; set; } = null!;

        public ICollection<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
    }
}