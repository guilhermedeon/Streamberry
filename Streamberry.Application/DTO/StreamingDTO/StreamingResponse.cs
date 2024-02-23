using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamberry.Application.DTO.StreamingDTO
{
    public class StreamingResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sinopse { get; set; }
        public int Duracao { get; set; }
        public int GeneroId { get; set; }
    }
}
