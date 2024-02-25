namespace Streamberry.Domain.Entities
{
    public partial class Avaliacao : BaseEntity
    {
        public int Classificacao { get; set; }

        public string Comentario { get; set; }

        public int IdFilme { get; set; }

        public int IdUsuario { get; set; }

        public Filme Filme { get; set; }

        public Usuario Usuario { get; set; }
    }
}