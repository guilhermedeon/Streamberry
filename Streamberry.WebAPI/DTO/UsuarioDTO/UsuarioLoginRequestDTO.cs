using System.ComponentModel.DataAnnotations;

namespace Streamberry.WebAPI.DTO.UsuarioDTO
{
    public class UsuarioLoginRequestDTO
    {
        [Required(ErrorMessage = "O email do usuário é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email do usuário não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha do usuário é obrigatória.")]
        public string Senha { get; set; }
    }
}