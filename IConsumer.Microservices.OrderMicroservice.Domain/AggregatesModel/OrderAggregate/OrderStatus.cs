using IConsumer.Microservices.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate
{
    public class OrderStatus : TEntity<int>
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
    }
}
