using IConsumer.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.App.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Order order, Guid tableId);
        Task<IEnumerable<Order>> GetStoreNewOrdersAsync();
        Task<IEnumerable<Order>> GetCustomerOpenOrdersAsync();
        Task<IEnumerable<Order>> GetStoreOpenedOrdersAsync();
        Task<Order> UpdateOrderStatusAsync(Guid orderId, OrderStatus orderStatus);
    }
}
