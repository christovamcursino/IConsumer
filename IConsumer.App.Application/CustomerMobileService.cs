using IConsumer.App.Application.Interfaces;
using IConsumer.App.Application.Models.Dtos;
using IConsumer.App.Domain.Entities;
using IConsumer.App.Domain.Interfaces.Services;
using IConsumer.App.Domain.Services;
using IConsumer.App.Infra.DataAccess.Repositories;
using IConsumer.App.Infra.DataAccess.Serializer;
using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.App.Application
{
    public class CustomerMobileService : IAppCustomerService
    {
        private ICustomerService _customerService;
        private IOrderService _orderService;
        private IProductService _productService;
        private IStoreService _storeService;

        private string token;

        public async Task AddCustomer(Customer customer)
        {
            await _customerService.CreateCustomerAsync(customer);
        }

        public async Task CreateOrder(Guid storeTableId, Order order)
        {
            await _orderService.CreateOrderAsync(order, storeTableId);
        }

        public async Task<Customer> GetCustomer(Guid customerId)
        {
            return await _customerService.GetCustomerAsync(customerId);
        }

        public async Task<IEnumerable<Order>> GetCustomerOrders()
        {
            return await _orderService.GetCustomerOpenOrdersAsync();
        }

        public async Task<IEnumerable<ProductType>> GetMenu(Guid storeId)
        {
            return await _productService.GetMenuAsync(storeId);
        }

        public async Task<Store> GetStore(Guid storeId)
        {
            return await _storeService.GetStoreAsync(storeId);
        }

        public async Task<StoreTable> GetTable(Guid storeTableId)
        {
            return await _storeService.GetStoreTableAsync(storeTableId);
        }

        public bool SignIn(string username, string password)
        {
            token = GetToken(username, password);
            if (String.IsNullOrEmpty(token))
                return false;

            registerServices();
            return true;
        }

        public bool SignUp(UserPasswordDto userPassword)
        {
            var token = GetAdminToken();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            var serializedUserPassword = JsonConvert.SerializeObject(userPassword);
            var httpContent = new StringContent(serializedUserPassword, Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://iconsumer-ccursino-iam-microservice-api.azurewebsites.net/api/UsersAndRoles", httpContent).Result;

            if (!result.IsSuccessStatusCode)
                return false;
            return true;
        }

        private string GetToken(string username, string password)
        {
            var client = new HttpClient();
            var response = client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = "https://iconsumer-ccursino-iam-microservice-identity.azurewebsites.net/connect/token",

                ClientId = "IConsumerMobileApp_ClientId",

                UserName = username,
                Password = password
            }).Result;

            return response.AccessToken;
        }

        private string GetAdminToken()
        {
            var client = new HttpClient();
            var response = client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = "https://iconsumer-ccursino-iam-microservice-identity.azurewebsites.net/connect/token",

                ClientId = "IConsumerMobileApp_ClientId",

                UserName = "admin",
                Password = "@dsInf123"
            }).Result;

            return response.AccessToken;
        }

        private void registerServices()
        {
            _customerService = new CustomerRemoteService(new CustomerMicroserviceRepository(token, new SerializerService()));
            _orderService = new OrderRemoteService(new OrderMicroserviceRepository(token, new SerializerService()));
            _productService = new ProductRemoteService(new ProductMicroserviceRepository(token, new SerializerService()),
                new ProductTypeMicroserviceRepository(token, new SerializerService()));
            _storeService = new StoreRemoteService(new StoreMicroserviceRepository(token, new SerializerService()));
        }
    }
}
