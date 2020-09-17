using IConsumer.App.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.App.Domain.Entities
{
    public class Product : TEntity<Guid>
    {
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        public Guid ProductTypeId { get; set; }
    }
}
