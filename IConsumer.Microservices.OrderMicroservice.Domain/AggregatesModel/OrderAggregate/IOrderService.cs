using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate
{
    public interface IOrderService
    {
        Order CreateOrder(Order order);
        IEnumerable<Order> GetCustomerOrders(Guid customerId);
        IEnumerable<Order> GetStoreNewOrders(Guid storeId);
    }
}
