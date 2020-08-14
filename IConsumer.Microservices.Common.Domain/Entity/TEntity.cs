using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.Common.Domain.Entity
{
    public abstract class TEntity<TId>
    {
        public TId Id { get; set; }
    }
}
