using Streamberry.Domain.Entities;
using Streamberry.WebAPI.DTO.FilmeDTO;
using Streamberry.WebAPI.DTO.UsuarioDTO;

namespace Streamberry.WebAPI.DTO.AvaliacaoDTO
{
    public class AvaliacaoResponseDTO
    {
        public int Id { get; set; }
        public int Classificacao { get; set; }
        public string Comentario { get; set; }
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
            excludes.Add(typeof(AvaliacaoResponseDTO));
            if (!excludes.Contains(typeof(FilmeResponseDTO)) && avaliacao.Filme != null)
            {
                excludes.Add(typeof(AvaliacaoResponseDTO));
                Filme = new FilmeResponseDTO(avaliacao.Filme, excludes);
            }
            if (!excludes.Contains(typeof(UsuarioResponseDTO)) && avaliacao.Usuario != null)
            {
                Usuario = new UsuarioResponseDTO(avaliacao.Usuario, excludes);
            }
        }
    }
}
