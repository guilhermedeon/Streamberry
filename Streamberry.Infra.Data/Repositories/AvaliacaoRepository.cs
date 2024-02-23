using Streamberry.Domain.Abstractions;
using Streamberry.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamberry.Infra.Data.Repositories
{
    internal class AvaliacaoRepository : IAvaliacaoRepository
    {
        private StreamberryContext _context;

        public AvaliacaoRepository(StreamberryContext context)
        {
            _context = context;
        }

    }
}
