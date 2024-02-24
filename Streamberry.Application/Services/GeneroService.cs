using Streamberry.Domain.Abstractions;
using Streamberry.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamberry.Application.Services
{
    public class GeneroService : BaseService<IGeneroRepository, Genero>
    {
        private readonly IGeneroRepository _generoRepository;
        public GeneroService(IGeneroRepository repository) : base(repository)
        {
            _generoRepository = repository;
        }

        public Genero? GetByName(string nome)
        {
            return _generoRepository.GetAll().Result.FirstOrDefault(g => g.Nome == nome);
        }
    }
}
