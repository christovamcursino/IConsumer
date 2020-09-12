using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.Microservices.Common.Domain.Repository
{
    public interface IQueryRepository<TId, T>
    {
        Task<T> ReadAsync(TId id);
        IEnumerable<T> ReadAll();
        Task<IEnumerable<T>> ReadAllAsync();
    }
}
