using IConsumer.Microservices.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate
{
    public class OrderItem : TEntity<Guid>
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public Decimal Price { get; set; }
        public int Amount { get; set; }
    }
}

