using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Streamberry.Domain.Entities
{
    public partial class Streaming : BaseEntity
    {
        public string Nome { get; set; } = null!;

        public ICollection<Filme> Filmes { get; set; } = new List<Filme>();
    }
}
