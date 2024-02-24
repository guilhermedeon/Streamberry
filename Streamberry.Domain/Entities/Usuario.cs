using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Streamberry.Domain.Entities
{
    public partial class Usuario : BaseEntity
    {

        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "O email do usuário é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email do usuário não é válido.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "A senha do usuário é obrigatória.")]
        public string Senha { get; set; } = null!;

        public ICollection<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
    }
}
