using IConsumer.Microservices.Common.Domain.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IConsumer.Microservices.StoreMicroservice.Domain.AggregatesModel.StoreAggregate
{
    public class StoreService : IStoreService
    {
        private IUnitOfWork _uow;
        private readonly IStoreRepository _storeRepository;
        private readonly IStoreTableRepository _storeTableRepository;

        public StoreService(IUnitOfWork uow, IStoreRepository storeRepository, IStoreTableRepository storeTableRepository)
        {
            _uow = uow;
            _storeRepository = storeRepository;
            _storeTableRepository = storeTableRepository;
        }

        public Store AddStore(Guid id, Store store)
        {
            _uow.BeginTransaction();
            store.Id = id;
            var result = _storeRepository.Insert(store);
            _uow.Commit();
            return result;
        }

        public Store EditStore(Guid id, Store store)
        {
            _uow.BeginTransaction();
            store.Id = id;
            _storeRepository.Update(store);
            _uow.Commit();
            return store;
        }

        public Store AddTablesToStore(Guid id, int tableAmount)
        {
            _uow.BeginTransaction();

            var store = GetStore(id);
            var maxTableNumber = store.StoreTables.Count() > 0 ? store.StoreTables.Max(o => o.TableNumber) : 0;

            for (int i=0; i < tableAmount; i++)
            {
                store.AddTable(++maxTableNumber);
            }

            _storeRepository.Update(store);

            _uow.Commit();
            return store;
        }

        public Store GetStore(Guid id)
        {
            return _storeRepository.GetByID(id);
        }

        public StoreTable GetStoreTableById(Guid storeTableId)
        {
            var result = _storeTableRepository.GetByID(storeTableId);
            //TODO: check if store is in object
            return result;
        }
    }
}
