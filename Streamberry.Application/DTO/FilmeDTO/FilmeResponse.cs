using Streamberry.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamberry.Application.DTO.FilmeDTO
{
    public class FilmeResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Sinopse { get; set; }
        public int Duracao { get; set; }
        public Genero? Genero { get; set; }
        public ICollection<Avaliacao>? Avaliacoes { get; set; }
    }
}
