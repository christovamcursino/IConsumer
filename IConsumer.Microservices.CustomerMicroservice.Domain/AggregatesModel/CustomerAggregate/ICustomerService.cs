using IConsumer.Microservices.Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.CustomerMicroservice.Domain.AggregatesModel.CustomerAggregate
{
    public interface ICustomerService  
    {
        /// <summary>
        /// Cria um novo customer. O ID devera vir do IAM
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Customer AddCustomer(Guid id, Customer customer);
        Customer EditCustomer(Guid id, Customer customer);
        Customer GetCustomer(Guid id);
    }
}
