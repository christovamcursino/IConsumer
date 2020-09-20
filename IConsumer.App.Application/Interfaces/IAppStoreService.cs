using IConsumer.App.Application.Models.ViewModels;
using IConsumer.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.App.Application.Interfaces
{
    public interface IAppStoreService : IAppService
    {
        Task AddStore(Store store);
        Task<Store> GetStore(Guid storeId);
        Task<Store> AddTables(int amount);
        Task AddProductType(ProductType productType);

        Task AddProduct(Product product);

        Task<IEnumerable<Order>> GetNewOrders();
        
        Task<StoreOrdersViewModel> GetOpenedOrders();

        Task UpdateOrderStatus(Guid orderId, OrderStatus orderStatus);

        void RegisterToken(Task<string> tokenAsync, string storeId);
    }
}
