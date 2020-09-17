using IConsumer.App.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.App.Domain.Entities
{
    public class OrderTracking : TEntity<Guid>
    {
        public DateTime TrackingDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
