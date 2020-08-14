﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.StoreMicroservice.Domain.AggregatesModel.StoreAggregate
{
    public struct Address
    {
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Town { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}