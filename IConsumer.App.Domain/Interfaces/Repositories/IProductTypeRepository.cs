using IConsumer.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.App.Domain.Interfaces.Repositories
{
    public interface IProductTypeRepository
    {
        Task CreateAsync(ProductType productType);
        Task<ProductType> ReadAsync(Guid productTypeId);
        Task<IEnumerable<ProductType>> ReadAllAsync();
        Task<IEnumerable<ProductType>> ReadMenuAsync(Guid storeId);
    }
}
