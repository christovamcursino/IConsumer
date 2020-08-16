using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.ProcuctMicroservice.Domain.AggregatesModel.ProductAggregate
{
    public interface IProductService
    {
        /// <summary>
        /// Recupera o menu do restaurante
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        ICollection<ProductType> GetMenu(Guid storeId);

        Product GetProduct(Guid productId);
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
    }
}
