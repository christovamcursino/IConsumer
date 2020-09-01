using IConsumer.Microservices.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.PaymentMicroservice.Domain.AggregatesModel.InvoicetAggregate
{
    public class Invoice : TEntity<Guid>
    {
        public DateTime InvoiceDate { get; set; }
        public decimal InvoiceTotal { get; set; }
        //public EStatus InvoiceStatus { get; set; }
    }
}
