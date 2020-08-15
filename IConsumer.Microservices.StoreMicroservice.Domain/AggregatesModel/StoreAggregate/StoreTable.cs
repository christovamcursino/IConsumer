﻿using IConsumer.Microservices.Common.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.StoreMicroservice.Domain.AggregatesModel.StoreAggregate
{
    public class StoreTable : TEntity<Guid>
    {
        public Store Store;
        public StoreTable() { }
        public StoreTable(Guid id, Store store, int tableNumber)
        {
            this.Id = id;
            this.Store = store;
            this.TableNumber = tableNumber;
        }

        public int TableNumber { get; set; }
    }
}
