using Streamberry.Domain.Abstractions;
using Streamberry.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamberry.Application.Services
{
    public class FilmeService : BaseService<IFilmeRepository,Filme>
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository) : base(filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }
    }
}
