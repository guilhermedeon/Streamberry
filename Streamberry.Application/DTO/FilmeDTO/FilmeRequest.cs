using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamberry.Application.DTO.FilmeDTO
{
    public class FilmeRequest
    {
        public required string Nome { get; set; }
        public required string Sinopse { get; set; }
        public required int Duracao { get; set; }
        public required int GeneroId { get; set; }
    }
}
