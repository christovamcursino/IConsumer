using IConsumer.Microservices.Common.Domain.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.ProcuctMicroservice.Domain.AggregatesModel.ProductAggregate
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IUnitOfWork _uow;
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeService(IUnitOfWork uow, IProductTypeRepository productTypeRepository)
        {
            _uow = uow;
            _productTypeRepository = productTypeRepository;
        }

        public ProductType AddProductType(Guid storeId, ProductType productType)
        {
            _uow.BeginTransaction();
            productType.Id = Guid.NewGuid();
            productType.StoreId = storeId;
            var result = _productTypeRepository.Insert(productType);
            _uow.Commit();
            return result;
        }

        public ProductType GetProductType(Guid productTypeId)
        {
            return _productTypeRepository.GetByID(productTypeId);
        }

        public IEnumerable<ProductType> GetProductTypes(Guid storeId)
        {
            return _productTypeRepository.GetByStoreId(storeId);
        }
    }
}
