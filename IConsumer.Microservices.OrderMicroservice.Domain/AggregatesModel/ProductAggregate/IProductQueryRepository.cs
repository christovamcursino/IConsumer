using IConsumer.Microservices.Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.ProductAggregate
{
    public interface IProductQueryRepository : IQueryRepository<Guid, Product>
    {
    }
}
