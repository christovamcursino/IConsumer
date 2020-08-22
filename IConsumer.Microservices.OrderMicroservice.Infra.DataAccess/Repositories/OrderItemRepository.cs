using IConsumer.Microservices.Common.Infra.DataAccess.Repository;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.Infra.DataAccess.Repositories
{
    public class OrderItemRepository : RepositorySqlBase<Guid, OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(DbContext context) : base(context)
        {
        }
    }
}
