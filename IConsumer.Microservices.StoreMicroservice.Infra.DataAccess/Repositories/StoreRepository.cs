using IConsumer.Microservices.Common.Infra.DataAccess.Repository;
using IConsumer.Microservices.StoreMicroservice.Domain.AggregatesModel.StoreAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IConsumer.Microservices.StoreMicroservice.Infra.DataAccess.Repositories
{
    public class StoreRepository : RepositorySqlBase<Guid, Store>, IStoreRepository
    {
        public StoreRepository(DbContext context) : base(context)
        {
        }
    }
}
