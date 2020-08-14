using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate
{
    public class OrderTracking
    {
        public Guid Id { get; set; }
        public DateTime TrackingDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
