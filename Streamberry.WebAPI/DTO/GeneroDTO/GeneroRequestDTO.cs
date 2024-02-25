using System.ComponentModel.DataAnnotations;

namespace Streamberry.WebAPI.DTO.GeneroDTO
{
    public class GeneroRequestDTO
    {
        [Required(ErrorMessage = "O nome do gênero é obrigatório.")]
        public string Nome { get; set; }
    }
}