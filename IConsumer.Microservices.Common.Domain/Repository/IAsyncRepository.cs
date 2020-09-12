using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.Microservices.Common.Domain.Repository
{
    public interface IAsyncRepository<TId, T>
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(TId id);
        Task<T> ReadAsync(TId id);
        IEnumerable<T> ReadAll();
        Task<IEnumerable<T>> ReadAllAsync();
        void Update(T entity);
        Task<int> SaveChangesAsync();
    }
}
