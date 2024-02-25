using Streamberry.Domain.Entities;
using Streamberry.WebAPI.DTO.AvaliacaoDTO;

namespace Streamberry.WebAPI.DTO.UsuarioDTO
{
    public class UsuarioResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<AvaliacaoResponseDTO> Avaliacoes { get; set; }

        public UsuarioResponseDTO(Usuario usuario, List<Type> excludes = null)
        {
            if (excludes == null)
            {
                excludes = new();
            }
            Id = usuario.Id;
            Nome = usuario.Nome;
            Email = usuario.Email;
            if (!excludes.Contains(typeof(AvaliacaoResponseDTO)) && usuario.Avaliacoes.Count > 0)
            {
                Avaliacoes = new List<AvaliacaoResponseDTO>();
                foreach (var avaliacao in usuario.Avaliacoes)
                {
                    Avaliacoes.Add(new AvaliacaoResponseDTO(avaliacao, excludes));
                }
            }
        }
    }
}