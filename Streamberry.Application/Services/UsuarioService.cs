using Streamberry.Domain.Abstractions;
using Streamberry.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamberry.Application.Services
{
    public class UsuarioService : BaseService<IUsuarioRepository, Usuario>
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
    }
}
