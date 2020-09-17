using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.App.Common.Domain.Entity
{
    public abstract class TEntity<TId>
    {
        public TId Id { get; set; }
    }
}
