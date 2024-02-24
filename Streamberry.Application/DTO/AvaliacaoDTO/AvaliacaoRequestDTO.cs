using System.ComponentModel.DataAnnotations;

namespace Streamberry.Domain.DTOs
{
    public class AvaliacaoRequestDTO
    {
        [Required(ErrorMessage = "A classificação é obrigatória.")]
        public int? Classificacao { get; set; }

        [Required(ErrorMessage = "O comentário é obrigatório.")]
        public string? Comentario { get; set; }

        [Required(ErrorMessage = "O Id do filme é obrigatório.")]
        public int? IdFilme { get; set; }

        [Required(ErrorMessage = "O Id do usuário é obrigatório.")]
        public int? IdUsuario { get; set; }
    }
}