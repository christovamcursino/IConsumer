using IConsumer.App.Domain.Entities;
using IConsumer.App.Domain.Interfaces.Repositories;
using IConsumer.App.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.App.Domain.Services
{
    public class OrderRemoteService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderRemoteService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task CreateOrderAsync(Order order, Guid tableId)
        {
            await _orderRepository.CreateAsync(order, tableId);
        }

        public async Task<IEnumerable<Order>> GetCustomerOpenOrdersAsync()
        {
            return await _orderRepository.ReadCustomerOrdersAsync();
        }

        public async Task<IEnumerable<Order>> GetStoreNewOrdersAsync()
        {
            return await _orderRepository.ReadNewOrdersAsync();
        }

        public async Task<IEnumerable<Order>> GetStoreOpenedOrdersAsync()
        {
            return await _orderRepository.ReadStoreOpenedOrdersAsync();
        }

        public async Task<Order> UpdateOrderStatusAsync(Guid orderId, OrderStatus orderStatus)
        {
            return await _orderRepository.UpdateOrderStatusAsync(orderId, orderStatus);
        }
    }
}
