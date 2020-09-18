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
    public class CustomerMicroserviceRepository : MicroserviceRepositoryBase, ICustomerRepository
    {
        private static string _baseUrl = "http://iconsumer-ccursino-customermicroservice.azurewebsites.net/api/Customer";

        public CustomerMicroserviceRepository(string token, ISerializerService serializerService) : base(token, serializerService)
        {
        }

        public async Task CreateAsync(Customer customer)
        {
            var client = getHttpClient();
            var customerSerialized = _serializerService.Serialize(customer);
            var httpContent = new StringContent(customerSerialized, Encoding.UTF8, "application/json");
            await client.PostAsync(_baseUrl, httpContent);
        }

        public async Task<Customer> ReadAsync(Guid id)
        {
            var client = getHttpClient();
            var result = await client.GetAsync(_baseUrl + "/" + id.ToString());

            var customerSerialized = await result.Content.ReadAsStringAsync();
            var customer = _serializerService.Deserialize<Customer>(customerSerialized);

            return customer;
        }
    }
}
