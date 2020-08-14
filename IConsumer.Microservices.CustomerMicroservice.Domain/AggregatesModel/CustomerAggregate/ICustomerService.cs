using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.CustomerMicroservice.Domain.AggregatesModel.CustomerAggregate
{
    public interface ICustomerService
    {
        Customer AddCustomer(Customer customer);
    }
}
