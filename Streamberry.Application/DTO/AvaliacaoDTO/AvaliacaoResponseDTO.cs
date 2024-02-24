using Streamberry.Domain.Entities;

namespace Streamberry.Domain.DTOs
{
    public class AvaliacaoResponseDTO
    {
        public int Id { get; set; }
        public int? Classificacao { get; set; }
        public string? Comentario { get; set; }
        public FilmeResponseDTO Filme { get; set; }
        public UsuarioResponseDTO Usuario { get; set; }

        public AvaliacaoResponseDTO(Avaliacao avaliacao, List<Type> excludes = null)
        {
            if (excludes == null)
            {
                excludes = new();
            }
            Id = avaliacao.Id;
            Classificacao = avaliacao.Classificacao;
            Comentario = avaliacao.Comentario;
            excludes.Add (typeof (AvaliacaoResponseDTO));
            if (!excludes.Contains(typeof (FilmeResponseDTO)))
            {
                excludes.Add (typeof (AvaliacaoResponseDTO));
                Filme = new FilmeResponseDTO(avaliacao.Filme, excludes);
            }
            if (!excludes.Contains(typeof (UsuarioResponseDTO)))
            {
                Usuario = new UsuarioResponseDTO(avaliacao.Usuario);
            }
        }
    }
}
