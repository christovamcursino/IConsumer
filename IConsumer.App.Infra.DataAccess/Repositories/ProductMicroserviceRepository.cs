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
    public class ProductMicroserviceRepository : MicroserviceRepositoryBase, IProductRepository
    {
        private static string _baseUrl = "https://iconsumer-ccursino-productmicroservice.azurewebsites.net/api/Product";

        public ProductMicroserviceRepository(string token, ISerializerService serializerService) : base(token, serializerService)
        {
        }

        public async Task CreateAsync(Product product)
        {
            var client = getHttpClient();
            var productSerialized = _serializerService.Serialize(product);
            var httpContent = new StringContent(productSerialized, Encoding.UTF8, "application/json");
            await client.PostAsync(_baseUrl, httpContent);
        }

        public async Task<Product> ReadAsync(Guid productId)
        {
            var client = getHttpClient();
            var result = await client.GetAsync(_baseUrl + "/ " + productId.ToString());

            var productSerialized = await result.Content.ReadAsStringAsync();
            var product = _serializerService.Deserialize<Product>(productSerialized);

            return product;
        }
    }
}
