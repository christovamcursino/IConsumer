using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate
{
    public interface IOrderStatusService
    {
        void AddTracking(Guid orderId, OrderStatus orderStatus);
    }
}
