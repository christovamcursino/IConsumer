using IConsumer.Microservices.Common.Domain.Services;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.ProductAggregate;
using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.Microservices.OrderMicroservice.Infra.DataAccess.Repositories
{
    public class ProductMicroserviceQueryRepository : IProductQueryRepository
    {
        private ISerializerService _serializerService;

        private static string _baseUrl = "https://iconsumer-ccursino-productmicroservice.azurewebsites.net/api/Product";

        public ProductMicroserviceQueryRepository(ISerializerService serializerService)
        {
            this._serializerService = serializerService;
        }

        public IEnumerable<Product> ReadAll()
        {
            var token = GetToken();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            var result = client.GetAsync(_baseUrl).Result;

            var serializedProducts = result.Content.ReadAsStringAsync().Result;
            var products = _serializerService.Deserialize<IEnumerable<Product>>(serializedProducts);

            return products;
        }

        public async Task<IEnumerable<Product>> ReadAllAsync()
        {
            var token = GetToken();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            var result = await client.GetAsync(_baseUrl);

            var serializedProducts = await result.Content.ReadAsStringAsync();
            var products = _serializerService.Deserialize<IEnumerable<Product>>(serializedProducts);

            return products;
        }

        public async Task<Product> ReadAsync(Guid id)
        {
            var token = GetToken();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            var result = await client.GetAsync(_baseUrl + "/ " + id.ToString());

            var serializedProduct = await result.Content.ReadAsStringAsync();
            var product = _serializerService.Deserialize<Product>(serializedProduct);

            return product;
        }

        private string GetToken()
        {
            var client = new HttpClient();
            var response = client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = "https://iconsumer-ccursino-iam-microservice-identity.azurewebsites.net/connect/token",

                ClientId = "IConsumerOrderMicroservice_ClientId"
            }).Result;

            return response.AccessToken;
        }
    }
}
