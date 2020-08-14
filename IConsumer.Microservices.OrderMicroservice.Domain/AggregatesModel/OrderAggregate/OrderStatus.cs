using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate
{
    public struct OrderStatus
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
    }
}
