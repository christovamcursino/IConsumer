using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.StoreAggregate
{
    public class StoreTableQueryService : IStoreTableQueryService
    {
        private readonly IStoreTableQueryRepository _storeTableQueryRepository;

        public StoreTableQueryService(IStoreTableQueryRepository storeTableQueryRepository)
        {
            _storeTableQueryRepository = storeTableQueryRepository;
        }

        public async Task<StoreTable> GetStoreTableAsync(Guid storeTableId)
        {
            return await _storeTableQueryRepository.ReadAsync(storeTableId);
        }
    }
}
