using IConsumer.Microservices.Common.Domain.Services;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.StoreAggregate;
using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.Microservices.OrderMicroservice.Infra.DataAccess.Repositories
{
    public class StoreTableMicroserviceQueryRepository : IStoreTableQueryRepository
    {
        private readonly ISerializerService _serializerService;

        private static string _baseUrl = "https://iconsumer-ccursino-storemicroservice.azurewebsites.net/api/StoreTable";

        public StoreTableMicroserviceQueryRepository(ISerializerService serializerService)
        {
            _serializerService = serializerService;
        }

        public async Task<StoreTable> ReadAsync(Guid id)
        {
            var token = GetToken();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            var result = await client.GetAsync(_baseUrl + "/ " + id.ToString());

            var serializedStoreTable = await result.Content.ReadAsStringAsync();
            var storeTable = _serializerService.Deserialize<StoreTable>(serializedStoreTable);

            return storeTable;
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
