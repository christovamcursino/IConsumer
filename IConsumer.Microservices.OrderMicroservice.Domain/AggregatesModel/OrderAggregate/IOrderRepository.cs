using IConsumer.Microservices.Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate
{
    public interface IOrderRepository : IAsyncRepository<Guid, Order>
    {
        public Task<Order> FilterOrdersOfCustomer(Guid customerId);
        public Task<Order> FilterNewOrders(Guid storeId);
    }
}
