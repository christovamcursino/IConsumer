using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.ProcuctMicroservice.Domain.AggregatesModel.ProductAggregate
{
    public class ProductType
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
