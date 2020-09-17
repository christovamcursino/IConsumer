using IConsumer.App.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.App.Domain.Entities
{
    public class Order : TEntity<Guid>
    {
        public Guid CustomerId { get; set; }
        public Guid StoreId { get; set; }
        public Guid TableId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<OrderTracking> TrackingHistory { get; set; }

        public bool PaymentApproved { get; set; }
        public string PaymentId { get; set; }
    }
}
