using IConsumer.App.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IConsumer.Microservices.PaymentMicroservice.Api.Model
{
    public class InvoiceViewModel : TEntity<Guid>
    {
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public decimal InvoiceTotal { get; set; }
    }
}
