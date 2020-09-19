using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.PaymentMicroservice.Domain.AggregatesModel.InvoicetAggregate
{
    public class PaymentService : IPaymentService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public PaymentService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public Invoice MockInvoicePayment(Guid customerId, Guid orderId, decimal InvoiceTotal)
        {
            Invoice invoice = new Invoice
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                InvoiceDate = DateTime.Now,
                InvoiceTotal = InvoiceTotal,
                InvoiceStatus = InvoiceStatus.Paid,
                Payments = new List<Payment>()
            };

            invoice.Payments.Add(new Payment
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                Paid = true,
                PaymentDate = DateTime.Now,
                PaymentValue = InvoiceTotal,
                InvoiceId = invoice.Id
            });

            _invoiceRepository.Insert(invoice);

            return invoice;
        }

    }
}
