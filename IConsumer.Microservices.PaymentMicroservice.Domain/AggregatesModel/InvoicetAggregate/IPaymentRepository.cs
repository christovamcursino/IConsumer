using IConsumer.Microservices.Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.PaymentMicroservice.Domain.AggregatesModel.InvoicetAggregate
{
    public interface IPaymentRepository : IRepository<Guid, Payment>
    {

    }
}
