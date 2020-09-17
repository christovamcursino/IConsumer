using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.StoreAggregate
{
    public interface IStoreTableQueryRepository
    {
        Task<StoreTable> ReadAsync(Guid id);
    }
}
