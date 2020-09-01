using IConsumer.Microservices.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.PaymentMicroservice.Domain.AggregatesModel.InvoicetAggregate
{
    public class Payment : TEntity<Guid>
    {
        public DateTime PaymentDate { get; set; }

    }
}
