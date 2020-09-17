using IConsumer.Microservices.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.StoreAggregate
{
    public class StoreTable : TEntity<Guid>
    {
        public Guid StoreId { get; set; }
        public int TableNumber { get; set; }
    }
}
