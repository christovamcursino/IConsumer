using IConsumer.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.App.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task CreateProductAsync(Product product);
        Task<Product> GetProductAsync(Guid productId);

        Task CreateProductTypeAsync(ProductType productType);
        Task<ProductType> GetProductTypeAsync(Guid productTypeId);
        Task<IEnumerable<ProductType>> GetAllProductTypesAsync();
        Task<IEnumerable<ProductType>> GetMenuAsync(Guid storeId);
    }
}
