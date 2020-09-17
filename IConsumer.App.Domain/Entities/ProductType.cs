using IConsumer.App.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.App.Domain.Entities
{
    public class ProductType : TEntity<Guid>
    {
        public Guid StoreId { get; set; }
        public int Disposal { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
