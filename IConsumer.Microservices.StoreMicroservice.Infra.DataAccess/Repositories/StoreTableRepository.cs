using IConsumer.Microservices.Common.Infra.DataAccess.Repository;
using IConsumer.Microservices.StoreMicroservice.Domain.AggregatesModel.StoreAggregate;
using Microsoft.EntityFrameworkCore;
using System;

namespace IConsumer.Microservices.StoreMicroservice.Infra.DataAccess.Repositories
{
    public class StoreTableRepository : RepositorySqlBase<Guid, StoreTable>, IStoreTableRepository
    {
        public StoreTableRepository(DbContext context) : base(context)
        {
        }
    }
}