using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.PaymentAggregate
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Guid> ExecutePayment(Guid orderId, Guid customerId, decimal amount)
        {
            var invoice = new InvoiceDto
            {
                CustomerId = customerId,
                OrderId = orderId,
                InvoiceTotal = amount
            };
            var paidInvoice = await _paymentRepository.CreatePaymentAsync(invoice);

            return paidInvoice.Id;
        }
    }
}
