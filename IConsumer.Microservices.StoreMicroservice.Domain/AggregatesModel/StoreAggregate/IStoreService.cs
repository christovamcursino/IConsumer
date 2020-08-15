using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.StoreMicroservice.Domain.AggregatesModel.StoreAggregate
{
    public interface IStoreService
    {
        Store AddStore(Guid id, Store store);
        Store EditStore(Guid id, Store store);
        Store GetStore(Guid id);
        StoreTable GetStoreTableById(Guid storeTableId);
    }
}
