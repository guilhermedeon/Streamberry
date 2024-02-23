using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamberry.Application.DTO.AvaliacaoDTO
{
    public class AvaliacaoRequest
    {
        public required int Classificacao { get; set; }
        public required string Comentario { get; set; }
        public required int FilmeId { get; set; }
        public required int UsuarioId { get; set; }
    }
}
