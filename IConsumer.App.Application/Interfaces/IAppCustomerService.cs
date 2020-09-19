using IConsumer.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.App.Application.Interfaces
{
    public interface IAppCustomerService : IAppService
    {
        StoreTable CurrentTable { get; }
        Store CurrentStore { get; }

        Task<bool> DoCheckIn(Guid storeTableId);

        Task AddCustomer(Customer customer);
        Task<Customer> GetCustomer(Guid customerId);
        Task<StoreTable> GetTable(Guid storeTableId);
        Task<Store> GetStore(Guid storeId);
        Task<IEnumerable<ProductType>> GetMenu();

        Task CreateOrder(Order order);

        Task<IEnumerable<Order>> GetCustomerOrders();
    }
}
