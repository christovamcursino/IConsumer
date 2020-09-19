using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.PaymentAggregate
{
    public interface IPaymentService
    {
        Task<Guid> ExecutePayment(Guid orderId, Guid customerId, decimal amount);
    }
}
