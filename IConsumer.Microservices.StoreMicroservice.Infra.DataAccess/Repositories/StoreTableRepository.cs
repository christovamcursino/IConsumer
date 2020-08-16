using IConsumer.Microservices.Common.Infra.DataAccess.Repository;
using IConsumer.Microservices.StoreMicroservice.Domain.AggregatesModel.StoreAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IConsumer.Microservices.StoreMicroservice.Infra.DataAccess.Repositories
{
    public class StoreTableRepository : RepositorySqlBase<Guid, StoreTable>, IStoreTableRepository
    {
        public StoreTableRepository(DbContext context) : base(context)
        {
        }

        public ICollection<StoreTable> GetTablesOfStore(Guid storeId)
        {
            return _context.Set<StoreTable>()
                .Where(o => o.Store.Id.Equals(storeId)).ToList();
        }
    }
}