using IConsumer.Microservices.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IConsumer.Microservices.StoreMicroservice.Domain.AggregatesModel.StoreAggregate
{
    public class Store : TEntity<Guid>
    {
        public String CNPJ { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public IEnumerable<StoreTable> StoreTables { get; set; }

        public void AddTable(int tableNumber)
        {
            if (this.StoreTables==null)
            {
                this.StoreTables = new List<StoreTable>();
            }

            var obj = new StoreTable
            {
                Id = Guid.NewGuid(),
                TableNumber = tableNumber,
                Store = this
            };

            this.StoreTables.Concat<StoreTable>(new [] {obj});
        }
    }
}
