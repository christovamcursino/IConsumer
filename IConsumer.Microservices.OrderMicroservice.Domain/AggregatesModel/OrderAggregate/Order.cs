using IConsumer.Microservices.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate
{
    public class Order : TEntity<Guid>
    {
        public Guid CustomerId { get; set; }
        public Guid TableId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public IEnumerable<OrderItem> OrderItens { get; set; }
        public IEnumerable<OrderTracking> TrackingHistory { get; set; }
    }
}
