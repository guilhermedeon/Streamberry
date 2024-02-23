using Streamberry.Domain.Abstractions;
using Streamberry.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamberry.Infra.Data.Repositories
{
    internal class StreamingRepository : IStreamingRepository
    {
        private StreamberryContext _context;

        public StreamingRepository(StreamberryContext context)
        {
            _context = context;
        }
    }
}
