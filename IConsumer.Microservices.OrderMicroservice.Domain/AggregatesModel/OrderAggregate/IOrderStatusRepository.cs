using IConsumer.Microservices.Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate
{
    public interface IOrderStatusRepository : IRepository<int, OrderStatus>
    {
    }
}
