using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Streamberry.Domain.Abstractions;
using Streamberry.Infra.Data.Models;

namespace Streamberry.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private StreamberryContext _context;

        public UsuarioRepository(StreamberryContext context)
        {
            _context = context;
        }
    }
}
