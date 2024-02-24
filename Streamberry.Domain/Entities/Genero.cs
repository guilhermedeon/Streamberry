using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Streamberry.Domain.Entities
{
    public partial class Genero : BaseEntity
    {

        [Required(ErrorMessage = "O nome do gênero é obrigatório.")]
        public string Nome { get; set; } = null!;

        public ICollection<Filme> Filmes { get; set; } = new List<Filme>();
    }
}
