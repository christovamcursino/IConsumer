using IConsumer.App.Common.Domain.Services;
using IConsumer.App.Domain.Entities;
using IConsumer.App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.App.Infra.DataAccess.Repositories
{
    public class ProductTypeMicroserviceRepository : MicroserviceRepositoryBase, IProductTypeRepository
    {
        private static string _baseUrl = "https://iconsumer-ccursino-productmicroservice.azurewebsites.net/api/ProductType";

        public ProductTypeMicroserviceRepository(string token, ISerializerService serializerService) : base(token, serializerService)
        {
        }

        public async Task CreateAsync(ProductType productType)
        {
            var client = getHttpClient();
            var productTypeSerialized = _serializerService.Serialize(productType);
            var httpContent = new StringContent(productTypeSerialized, Encoding.UTF8, "application/json");
            await client.PostAsync(_baseUrl, httpContent);
        }

        public async Task<IEnumerable<ProductType>> ReadAllAsync()
        {
            var client = getHttpClient();
            var result = await client.GetAsync(_baseUrl);

            var productTypeSerialized = await result.Content.ReadAsStringAsync();
            var productTypes = _serializerService.Deserialize<IEnumerable<ProductType>>(productTypeSerialized);

            return productTypes;
        }

        public async Task<ProductType> ReadAsync(Guid productTypeId)
        {
            var client = getHttpClient();
            var result = await client.GetAsync(_baseUrl + "/" + productTypeId.ToString());

            var productTypeSerialized = await result.Content.ReadAsStringAsync();
            var productType = _serializerService.Deserialize<ProductType>(productTypeSerialized);

            return productType;
        }

        public async Task<IEnumerable<ProductType>> ReadMenuAsync(Guid storeId)
        {
            var client = getHttpClient();
            var result = await client.GetAsync(_baseUrl + "/store/" + storeId + "/menu");

            var productTypeSerialized = await result.Content.ReadAsStringAsync();
            var productTypes = _serializerService.Deserialize<IEnumerable<ProductType>>(productTypeSerialized);

            return productTypes;
        }
    }
}
