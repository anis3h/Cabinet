using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAsyncRepository<T> where T : EntityBase
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
