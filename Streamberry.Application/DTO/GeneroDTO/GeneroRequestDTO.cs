using System.ComponentModel.DataAnnotations;

namespace Streamberry.Domain.DTOs
{
    public class GeneroRequestDTO
    {
        [Required(ErrorMessage = "O nome do gênero é obrigatório.")]
        public string Nome { get; set; }
    }
}