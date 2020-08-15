using IConsumer.Microservices.Common.Domain.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.CustomerMicroservice.Domain.AggregatesModel.CustomerAggregate
{
    public class CustomerService : ICustomerService
    {
        private IUnitOfWork _uow;
        private ICustomerRepository _customerRepository;

        public CustomerService(IUnitOfWork uow, ICustomerRepository customerRepository)
        {
            _uow = uow;
            _customerRepository = customerRepository;
        }

        public Customer AddCustomer(Guid id, Customer customer)
        {
            _uow.BeginTransaction();
            customer.Id = id;
            Customer result = _customerRepository.Insert(customer);
            _uow.Commit();

            return result;
        }

        public Customer EditCustomer(Guid id, Customer customer)
        {
            customer.Id = id;
            _customerRepository.Update(customer);
            return customer;
        }

        public Customer GetCustomer(Guid id)
        {
            return _customerRepository.GetByID(id);
        }
    }
}
