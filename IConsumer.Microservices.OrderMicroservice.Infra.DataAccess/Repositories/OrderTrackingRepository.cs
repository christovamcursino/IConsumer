using IConsumer.Microservices.Common.Infra.DataAccess.Repository;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.Infra.DataAccess.Repositories
{
    public class OrderTrackingRepository : RepositorySqlBase<Guid, OrderTracking>, IOrderTrackingRepository
    {
        public OrderTrackingRepository(DbContext context) : base(context)
        {
        }
    }
}
