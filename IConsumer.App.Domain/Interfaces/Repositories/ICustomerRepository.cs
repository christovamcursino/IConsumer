using IConsumer.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.App.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task CreateAsync(Customer customer);
        Task<Customer> ReadAsync(Guid id);
    }
}
