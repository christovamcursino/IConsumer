using IConsumer.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.App.Application.Interfaces
{
    public interface IAppCustomerService : IAppService
    {
        Task AddCustomer(Customer customer);
        Task<Customer> GetCustomer(Guid customerId);
        Task<StoreTable> GetTable(Guid storeTableId);
        Task<Store> GetStore(Guid storeId);
        Task<IEnumerable<ProductType>> GetMenu(Guid storeId);

        Task CreateOrder(Guid storeTableId, Order order);

        Task<IEnumerable<Order>> GetCustomerOrders();
    }
}
