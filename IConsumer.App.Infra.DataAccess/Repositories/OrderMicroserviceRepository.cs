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
    public class OrderMicroserviceRepository : MicroserviceRepositoryBase, IOrderRepository
    {
        private static string _baseUrl = "https://iconsumer-ccursino-ordermicroservice.azurewebsites.net/api/order";

        public OrderMicroserviceRepository(string token, ISerializerService serializerService) : base(token, serializerService)
        {
        }

        public async Task CreateAsync(Order order, Guid tableId)
        {
            var client = getHttpClient();
            var orderSerialized = _serializerService.Serialize(order);
            var httpContent = new StringContent(orderSerialized, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(_baseUrl + "/table/" + tableId, httpContent);
            Console.WriteLine(result.Content);
        }

        public async Task<IEnumerable<Order>> ReadCustomerOrdersAsync()
        {
            var client = getHttpClient();
            var result = await client.GetAsync(_baseUrl + "/customer-orders");

            var ordersSerialized = await result.Content.ReadAsStringAsync();
            var orders = _serializerService.Deserialize<IEnumerable<Order>>(ordersSerialized);

            return orders;
        }

        public async Task<IEnumerable<Order>> ReadNewOrdersAsync()
        {
            var client = getHttpClient();
            var result = await client.GetAsync(_baseUrl + "/new-orders");

            var ordersSerialized = await result.Content.ReadAsStringAsync();
            var orders = _serializerService.Deserialize<IEnumerable<Order>>(ordersSerialized);

            return orders;
        }

        public async Task<IEnumerable<Order>> ReadStoreOpenedOrdersAsync()
        {
            var client = getHttpClient();
            var result = await client.GetAsync(_baseUrl + "/store-orders");

            var ordersSerialized = await result.Content.ReadAsStringAsync();
            var orders = _serializerService.Deserialize<IEnumerable<Order>>(ordersSerialized);

            return orders;
        }

        public async Task<Order> UpdateOrderStatusAsync(Guid orderId, OrderStatus orderStatus)
        {
            var client = getHttpClient();
            var orderStatusViewModel = new ChangeStatusViewModel{ OrderStatus = orderStatus };
            var orderSerialized = _serializerService.Serialize(orderStatusViewModel);
            var httpContent = new StringContent(orderSerialized, Encoding.UTF8, "application/json");
            
            var result = await client.PutAsync(_baseUrl + "/" + orderId + "/status", httpContent);

            var serializedOrders = await result.Content.ReadAsStringAsync();
            var order = _serializerService.Deserialize<Order>(serializedOrders);

            return order;
        }
    }
}
