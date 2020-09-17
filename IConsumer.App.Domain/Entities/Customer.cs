using IConsumer.App.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.App.Domain.Entities
{
    public class Customer : TEntity<Guid>
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string CPF { get; set; }
    }
}
