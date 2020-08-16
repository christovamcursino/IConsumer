using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.ProcuctMicroservice.Domain.AggregatesModel.ProductAggregate
{
    public interface IProductTypeService
    {
        /// <summary>
        /// Recupera uma lista simples com os tipos de pedido existentes
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        IEnumerable<ProductType> GetProductTypes(Guid storeId);

        ProductType GetProductType(Guid productTypeId);
        ProductType AddProductType(Guid storeId, ProductType productType);
    }
}
