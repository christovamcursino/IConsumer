using IConsumer.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.App.Domain.Interfaces.Repositories
{
    public interface IStoreRepository
    {
        Task CreateAsync(Store store);
        Task<Store> ReadAsync(Guid storeId);
        Task<Store> AddTablesAsync(int amount);
    }
}
