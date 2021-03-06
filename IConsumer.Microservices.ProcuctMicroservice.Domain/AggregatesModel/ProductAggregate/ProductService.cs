﻿using IConsumer.Microservices.Common.Domain.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IConsumer.Microservices.ProcuctMicroservice.Domain.AggregatesModel.ProductAggregate
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IProductRepository _productRepository;

        public ProductService(IUnitOfWork uow, IProductTypeRepository productTypeRepository, IProductRepository productRepository)
        {
            _uow = uow;
            _productTypeRepository = productTypeRepository;
            _productRepository = productRepository;
        }

        public Product AddProduct(Product product)
        {
            _uow.BeginTransaction();
            product.Id = Guid.NewGuid();
            var result = _productRepository.Insert(product);
            _uow.Commit();
            return result;
        }

        public ICollection<ProductType> GetMenu(Guid storeId)
        {
            var productTypes = _productTypeRepository.GetByStoreId(storeId).ToList();
            var result = new List<ProductType>();
            foreach (var item in productTypes)
            {
                item.Products = _productRepository.GetByProductType(item.Id);
                if (item.Products.Count() > 0)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public Product GetProduct(Guid productId)
        {
            return _productRepository.GetByID(productId);
        }

        public Product UpdateProduct(Product product)
        {
            _uow.BeginTransaction();
            _productRepository.Update(product);
            _uow.Commit();
            return product;
        }
    }
}

