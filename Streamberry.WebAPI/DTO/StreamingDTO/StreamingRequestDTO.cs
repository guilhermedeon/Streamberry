using System.ComponentModel.DataAnnotations;

namespace Streamberry.WebAPI.DTO.StreamingDTO
{
    public class StreamingRequestDTO
    {
        [Required(ErrorMessage = "O nome do streaming é obrigatório.")]
        public string Nome { get; set; }
    }
}