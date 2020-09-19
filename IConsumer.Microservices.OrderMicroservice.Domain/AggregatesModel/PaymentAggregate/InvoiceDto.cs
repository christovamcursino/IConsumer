using IConsumer.Microservices.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.PaymentAggregate
{
    public class InvoiceDto : TEntity<Guid>
    {
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public decimal InvoiceTotal { get; set; }
    }
}
