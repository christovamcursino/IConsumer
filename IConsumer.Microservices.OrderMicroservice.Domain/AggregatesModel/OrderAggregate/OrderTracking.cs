using IConsumer.Microservices.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate
{
    public class OrderTracking : TEntity<Guid>
    {
        public DateTime TrackingDate { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public Order Order { get; set; }
        public Guid OrderId { get; set; }
    }
}
