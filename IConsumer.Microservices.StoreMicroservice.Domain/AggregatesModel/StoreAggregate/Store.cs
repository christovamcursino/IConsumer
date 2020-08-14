using IConsumer.Microservices.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.StoreMicroservice.Domain.AggregatesModel.StoreAggregate
{
    public class Store : TEntity<Guid>
    {
        public String CNPJ { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public IEnumerable<StoreTable> StoreTables { get; set; }
    }
}
