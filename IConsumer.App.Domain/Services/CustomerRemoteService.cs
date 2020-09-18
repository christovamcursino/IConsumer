using IConsumer.App.Domain.Entities;
using IConsumer.App.Domain.Interfaces.Repositories;
using IConsumer.App.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.App.Domain.Services
{
    public class CustomerRemoteService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerRemoteService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            await _customerRepository.CreateAsync(customer);
        }

        public async Task<Customer> GetCustomerAsync(Guid id)
        {
            return await _customerRepository.ReadAsync(id);
        }
    }
}
