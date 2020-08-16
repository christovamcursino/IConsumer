using IConsumer.Microservices.Common.Infra.DataAccess.Repository;
using IConsumer.Microservices.ProcuctMicroservice.Domain.AggregatesModel.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.ProductMicroservice.Infra.DataAccess.Repositories
{
    public class ProductRepository : RepositorySqlBase<Guid, Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}
