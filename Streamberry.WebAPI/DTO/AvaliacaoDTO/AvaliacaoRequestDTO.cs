using System.ComponentModel.DataAnnotations;

namespace Streamberry.WebAPI.DTO.AvaliacaoDTO
{
    public class AvaliacaoRequestDTO
    {
        [Required(ErrorMessage = "A classificação é obrigatória.")]
        [Range(1, 5, ErrorMessage = "A classificação deve ser entre 1 e 5.")]
        public int Classificacao { get; set; }

        [Required(ErrorMessage = "O comentário é obrigatório.")]
        public string Comentario { get; set; }

        [Required(ErrorMessage = "O Id do filme é obrigatório.")]
        public int IdFilme { get; set; }

    }
}