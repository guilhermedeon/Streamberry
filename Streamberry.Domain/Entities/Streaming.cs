using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Streamberry.Domain.Entities
{
    public partial class Streaming : BaseEntity
    {

        [Required(ErrorMessage = "O nome do streaming é obrigatório.")]
        public string Nome { get; set; } = null!;

        public ICollection<Filme> Filmes { get; set; } = new List<Filme>();
    }
}
