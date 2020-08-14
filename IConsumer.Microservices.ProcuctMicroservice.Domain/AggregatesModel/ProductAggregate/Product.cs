using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.ProcuctMicroservice.Domain.AggregatesModel.ProductAggregate
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
