using IConsumer.App.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.App.Domain.Entities
{
    public class Store : TEntity<Guid>
    {
        public string CNPJ { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public ICollection<StoreTable> StoreTables { get; set; }
    }
}
