using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.StoreMicroservice.Domain.AggregatesModel.StoreAggregate
{
    public class StoreTable
    {
        public Guid Id { get; set; }
        public int TableNumber { get; set; }
    }
}
