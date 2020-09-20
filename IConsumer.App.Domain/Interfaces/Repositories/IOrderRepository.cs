using IConsumer.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.App.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task CreateAsync(Order order, Guid tableId);
        Task<IEnumerable<Order>> ReadNewOrdersAsync();
        Task<IEnumerable<Order>> ReadCustomerOrdersAsync();
        Task<IEnumerable<Order>> ReadStoreOpenedOrdersAsync();
        Task<Order> UpdateOrderStatusAsync(Guid orderId, OrderStatus orderStatus);
    }
}
