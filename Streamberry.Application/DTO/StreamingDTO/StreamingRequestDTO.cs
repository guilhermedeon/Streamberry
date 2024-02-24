using System.ComponentModel.DataAnnotations;

namespace Streamberry.Domain.DTOs
{
    public class StreamingRequestDTO
    {
        [Required(ErrorMessage = "O nome do streaming é obrigatório.")]
        public string Nome { get; set; }
    }
}