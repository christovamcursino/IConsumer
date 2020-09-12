using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate
{
    public interface IOrderService
    {
        public Order CreateOrder(Guid customerId, Guid tableId, ICollection<OrderItem> orderItems);
        public Task<bool> ProcessOrderAsync(Order order);

        public Task<IEnumerable<Order>> GetCustomerOrders(Guid customerId);
        public Task<IEnumerable<Order>> GetStoreNewOrders(Guid storeId);

        public Task<bool> SetOrderStatus(Guid orderId, OrderStatus orderStatus);
    }
}
