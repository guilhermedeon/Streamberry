using System.ComponentModel.DataAnnotations;

namespace Streamberry.Domain.DTOs
{
    public class UsuarioRequestDTO
    {
        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email do usuário é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email do usuário não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha do usuário é obrigatória.")]
        public string Senha { get; set; }
    }
}