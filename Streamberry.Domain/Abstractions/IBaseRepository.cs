using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamberry.Domain.Abstractions
{
    public interface IBaseRepository<T>
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
