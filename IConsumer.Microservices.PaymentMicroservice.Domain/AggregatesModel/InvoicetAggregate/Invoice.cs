using IConsumer.Microservices.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.PaymentMicroservice.Domain.AggregatesModel.InvoicetAggregate
{
    public class Invoice : TEntity<Guid>
    {
        public Guid OrderId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal InvoiceTotal { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }

    public enum InvoiceStatus
    {
        Created = 0,
        Paid = 1,
        Cancelled = 2
    }
}
