using IConsumer.Microservices.Common.Domain.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.PaymentMicroservice.Domain.AggregatesModel.InvoicetAggregate
{
    public class PaymentService : IPaymentService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private IUnitOfWork _uow;

        public PaymentService(IInvoiceRepository invoiceRepository, IUnitOfWork uow)
        {
            _invoiceRepository = invoiceRepository;
            _uow = uow;
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

            _uow.BeginTransaction();
            _invoiceRepository.Insert(invoice);
            _uow.Commit();

            return invoice;
        }

    }
}
