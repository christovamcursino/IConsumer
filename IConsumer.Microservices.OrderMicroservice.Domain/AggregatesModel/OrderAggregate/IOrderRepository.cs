using IConsumer.Microservices.Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate
{
    public interface IOrderRepository : IAsyncRepository<Guid, Order>
    {
        public Task<IEnumerable<Order>> FilterOrdersOfCustomer(Guid customerId);
        public Task<IEnumerable<Order>> FilterNewOrders(Guid storeId);
    }
}
