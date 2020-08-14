using IConsumer.Microservices.Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.CustomerMicroservice.Domain.AggregatesModel.CustomerAggregate
{
    public interface ICustomerRepository : IRepository<Guid, Customer>
    {
    }
}
