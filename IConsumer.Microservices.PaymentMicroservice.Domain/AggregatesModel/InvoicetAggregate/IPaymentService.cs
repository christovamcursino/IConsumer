using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.PaymentMicroservice.Domain.AggregatesModel.InvoicetAggregate
{
    public interface IPaymentService
    {
        Invoice MockInvoicePayment(Guid customerId, Guid orderId, decimal InvoiceTotal);
    }
}
