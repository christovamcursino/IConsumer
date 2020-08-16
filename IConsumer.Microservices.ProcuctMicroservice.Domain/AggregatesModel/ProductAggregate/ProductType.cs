using IConsumer.Microservices.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.ProcuctMicroservice.Domain.AggregatesModel.ProductAggregate
{
    public class ProductType : TEntity<Guid>
    {
        public Guid StoreId { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
