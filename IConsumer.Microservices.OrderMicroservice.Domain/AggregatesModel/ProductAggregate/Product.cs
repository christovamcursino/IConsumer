using IConsumer.Microservices.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.ProductAggregate
{
    public class Product : TEntity<Guid>
    {
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
