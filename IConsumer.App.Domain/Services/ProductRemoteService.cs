using IConsumer.App.Domain.Entities;
using IConsumer.App.Domain.Interfaces.Repositories;
using IConsumer.App.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.App.Domain.Services
{
    public class ProductRemoteService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductRemoteService(IProductRepository productRepository, IProductTypeRepository productTypeRepository)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
        }

        public async Task CreateProductAsync(Product product)
        {
            await _productRepository.CreateAsync(product);
        }

        public async Task CreateProductTypeAsync(ProductType productType)
        {
            await _productTypeRepository.CreateAsync(productType);
        }

        public async Task<IEnumerable<ProductType>> GetAllProductTypesAsync()
        {
            return await _productTypeRepository.ReadAllAsync();
        }

        public async Task<IEnumerable<ProductType>> GetMenuAsync(Guid storeId)
        {
            return await _productTypeRepository.ReadMenuAsync(storeId);
        }

        public async Task<Product> GetProductAsync(Guid productId)
        {
            return await _productRepository.ReadAsync(productId);
        }

        public async Task<ProductType> GetProductTypeAsync(Guid productTypeId)
        {
            return await _productTypeRepository.ReadAsync(productTypeId);
        }
    }
}
