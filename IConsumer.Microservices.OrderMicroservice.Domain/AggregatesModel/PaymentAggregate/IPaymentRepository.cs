using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.PaymentAggregate
{
    public interface IPaymentRepository
    {
        Task<InvoiceDto> CreatePaymentAsync(InvoiceDto invoice);
    }
}
