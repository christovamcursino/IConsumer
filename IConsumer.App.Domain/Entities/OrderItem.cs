using IConsumer.App.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.App.Domain.Entities
{
    public class OrderItem : TEntity<Guid>
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public Decimal Price { get; set; }
        public int Amount { get; set; }
    }
}
