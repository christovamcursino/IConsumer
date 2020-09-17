using IConsumer.App.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.App.Domain.Entities
{
    public class StoreTable : TEntity<Guid>
    {
        public Guid StoreId { get; set; }
        public int TableNumber { get; set; }
    }
}
