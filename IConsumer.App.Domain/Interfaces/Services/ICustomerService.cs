using IConsumer.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.App.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Task CreateCustomerAsync(Customer customer);
        Task<Customer> GetCustomerAsync(Guid id);
    }
}
