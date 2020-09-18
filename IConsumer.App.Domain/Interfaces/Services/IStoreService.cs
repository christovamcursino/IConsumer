using IConsumer.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.App.Domain.Interfaces.Services
{
    public interface IStoreService
    {
        Task CreateStoreAsync(Store store);
        Task<Store> GetStoreAsync(Guid storeId);
        Task<Store> AddTablesToStoreAsync(int amount);
        Task<StoreTable> GetStoreTableAsync(Guid storeTableId);
    }
}
