using IConsumer.Microservices.Common.Infra.DataAccess.Repository;
using IConsumer.Microservices.ProcuctMicroservice.Domain.AggregatesModel.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IConsumer.Microservices.ProductMicroservice.Infra.DataAccess.Repositories
{
    public class ProductRepository : RepositorySqlBase<Guid, Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }

        public ICollection<Product> GetByProductType(Guid productTypeId)
        {
            return _context.Set<Product>()
                .Where(o => o.ProductTypeId.Equals(productTypeId))
                .ToList();
        }
    }
}
