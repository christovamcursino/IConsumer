using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.MicroServices.OrderMicroservice.Application.Services
{
    public interface IApiApplicationService
    {
        Task<Order> CreateOrderAsync(Guid customerId, Guid tableId, ICollection<OrderItem> orderItems);

        Task<IEnumerable<Order>> GetCustomerOpenedOrders(Guid customerId);
        Task<IEnumerable<Order>> GetStoreNewOrders(Guid storeId);
        Task<bool> ChangeOrderStatus(Guid storeId, Guid orderId, OrderStatus orderStatus);
    }
}
