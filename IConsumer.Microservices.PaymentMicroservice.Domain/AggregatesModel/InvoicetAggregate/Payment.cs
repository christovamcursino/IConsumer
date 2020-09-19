using IConsumer.Microservices.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace IConsumer.Microservices.PaymentMicroservice.Domain.AggregatesModel.InvoicetAggregate
{
    public class Payment : TEntity<Guid>
    {
        public DateTime PaymentDate { get; set; }
        public Guid CustomerId { get; set; }
        public decimal PaymentValue { get; set; }
        public bool Paid { get; set; }

        public Invoice Invoice { get; set; }
        public Guid InvoiceId { get; set; }
    }
}
