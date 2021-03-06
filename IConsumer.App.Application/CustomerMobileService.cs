﻿using IConsumer.App.Application.Interfaces;
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
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.App.Application
{
    public class CustomerMobileService : IAppCustomerService
    {
        private StoreTable _currentTable;
        private Store _currentStore;
        private IList<OrderItem> _cart;

        private ICustomerService _customerService;
        private IOrderService _orderService;
        private IProductService _productService;
        private IStoreService _storeService;

        private string token;

        public StoreTable CurrentTable { get => _currentTable; }
        public Store CurrentStore { get => _currentStore; }

        public IList<OrderItem> Cart { get => _cart; }

        public async Task<bool> DoCheckIn(Guid storeTableId)
        {
            _currentTable = await GetTable(storeTableId);
            if (_currentTable == null)
            {
                _currentStore = null;
                return false;
            }

            _currentStore = await GetStore(CurrentTable.StoreId);
            _cart = new List<OrderItem>();

            return true;
        }

        public async Task AddCustomer(Customer customer)
        {
            await _customerService.CreateCustomerAsync(customer);
        }

        public async Task CreateOrder()
        {
            Order order = new Order
            {
                OrderItems = this.Cart
            };
            await _orderService.CreateOrderAsync(order, CurrentTable.Id);

            this._cart = null;
        }

        public async Task<Customer> GetCustomer(Guid customerId)
        {
            return await _customerService.GetCustomerAsync(customerId);
        }

        public async Task<IEnumerable<Order>> GetCustomerOrders()
        {
            return await _orderService.GetCustomerOpenOrdersAsync();
        }

        public async Task<IEnumerable<ProductType>> GetMenu()
        {
            return await _productService.GetMenuAsync(CurrentStore.Id);
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

        public void AddProductToCart(Product product, int amount)
        {
            OrderItem item = new OrderItem();
            item.ProductId = product.Id;
            item.ProductName = product.Name;
            item.Price = product.Price;
            item.Amount = amount;
            this.Cart.Add(item);
        }

        public decimal GetCartTotal()
        {
            return this.Cart.Sum(o => o.Price * o.Amount);
        }
    }
}
