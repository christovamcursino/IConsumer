using IConsumer.App.Domain.Entities;
using IConsumer.App.Domain.Interfaces.Repositories;
using IConsumer.App.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.App.Domain.Services
{
    public class StoreRemoteService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreRemoteService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<Store> AddTablesToStoreAsync(int amount)
        {
            return await _storeRepository.AddTablesAsync(amount);
        }

        public async Task CreateStoreAsync(Store store)
        {
            await _storeRepository.CreateAsync(store);
        }

        public async Task<Store> GetStoreAsync(Guid storeId)
        {
            return await _storeRepository.ReadAsync(storeId);
        }
    }
}
