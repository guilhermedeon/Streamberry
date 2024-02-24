using Streamberry.Domain.Abstractions;
using Streamberry.Domain.Entities;

namespace Streamberry.Application.Services
{
    public abstract class BaseService<T, Y> where T : IBaseRepository<Y> where Y : BaseEntity
    {
        private readonly IBaseRepository<Y> _repository;

        public BaseService(IBaseRepository<Y> repository)
        {
            _repository = repository;
        }

        public virtual async Task<Y> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public virtual async Task<IEnumerable<Y>> GetAll()
        {
            return await _repository.GetAll();
        }

        public virtual void Add(Y entity)
        {
            _repository.Add(entity);
        }

        public virtual void Update(Y entity)
        {
            _repository.Update(entity);
        }

        public virtual void Remove(Y entity)
        {
            _repository.Remove(entity);
        }

        public bool EntityExists(int id)
        {
            var exists = _repository.GetAll().Result;
            return exists.Any(e => e.Id == id);
        }
    }
}