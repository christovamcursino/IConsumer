using IConsumer.Microservices.Common.Infra.DataAccess.Repository;
using IConsumer.Microservices.ProcuctMicroservice.Domain.AggregatesModel.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IConsumer.Microservices.ProductMicroservice.Infra.DataAccess.Repositories
{
    public class ProductTypeRepository : RepositorySqlBase<Guid, ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<ProductType> GetByStoreId(Guid storeId)
        {
            return _context.Set<ProductType>()
                .Where(o => o.StoreId.Equals(storeId));
        }
    }
}
