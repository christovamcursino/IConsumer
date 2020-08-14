using IConsumer.Microservices.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.StoreMicroservice.Domain.AggregatesModel.StoreAggregate
{
    public class StoreTable : TEntity<Guid>
    {
        public int TableNumber { get; set; }
    }
}
