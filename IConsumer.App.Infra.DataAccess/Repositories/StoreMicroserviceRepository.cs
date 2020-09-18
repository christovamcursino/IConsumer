using IConsumer.App.Common.Domain.Services;
using IConsumer.App.Domain.Entities;
using IConsumer.App.Domain.Interfaces.Repositories;
using IConsumer.App.Infra.DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.App.Infra.DataAccess.Repositories
{
    public class StoreMicroserviceRepository : MicroserviceRepositoryBase, IStoreRepository
    {
        private static string _baseUrl = "https://iconsumer-ccursino-storemicroservice.azurewebsites.net/api/Store";

        public StoreMicroserviceRepository(string token, ISerializerService serializerService) : base(token, serializerService)
        {
        }

        public async Task<Store> AddTablesAsync(int amount)
        {
            var client = getHttpClient();
            var tablesViewModel = new AddTableViewModel {TablesAmount = amount};
            var tablesSerialized = _serializerService.Serialize(tablesViewModel);
            var httpContent = new StringContent(tablesSerialized, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(_baseUrl, httpContent);

            var storeSerialized = await result.Content.ReadAsStringAsync();
            var store = _serializerService.Deserialize<Store>(storeSerialized);

            return store;
        }

        public async Task CreateAsync(Store store)
        {
            var client = getHttpClient();
            var storeSerialized = _serializerService.Serialize(store);
            var httpContent = new StringContent(storeSerialized, Encoding.UTF8, "application/json");
            await client.PostAsync(_baseUrl, httpContent);
        }

        public async Task<Store> ReadAsync(Guid storeId)
        {
            var client = getHttpClient();
            var result = await client.GetAsync(_baseUrl + "/" + storeId.ToString());

            var storeSerialized = await result.Content.ReadAsStringAsync();
            var store = _serializerService.Deserialize<Store>(storeSerialized);

            return store;
        }

        public async Task<StoreTable> ReadStoreTableAsync(Guid storeTableId)
        {
            var client = getHttpClient();
            var result = await client.GetAsync(_baseUrl + "Table/" + storeTableId.ToString());

            var storeTableSerialized = await result.Content.ReadAsStringAsync();
            var storeTable = _serializerService.Deserialize<StoreTable>(storeTableSerialized);

            return storeTable;
        }
    }
}
