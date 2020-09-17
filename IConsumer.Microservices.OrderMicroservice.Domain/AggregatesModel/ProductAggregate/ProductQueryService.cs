using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.ProductAggregate
{
    public class ProductQueryService : IProductQueryService
    {
        private IProductQueryRepository _productQueryRepository;

        public ProductQueryService(IProductQueryRepository productQueryRepository)
        {
            this._productQueryRepository = productQueryRepository;
        }

        public async Task<Product> GetProductAsync(Guid productId)
        {
            return await _productQueryRepository.ReadAsync(productId);
        }
    }
}
