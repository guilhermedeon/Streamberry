using Streamberry.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamberry.Application.DTO.AvaliacaoDTO
{
    public class AvaliacaoResponse
    {
        public int Id { get; set; }
        public int Classificacao { get; set; }
        public string? Comentario { get; set; }
        public Filme? Filme { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
