using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using IConsumer.MicroServices.Common.Application.Interfaces.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.Application.CQRS.Events
{
    public abstract class OrderEvent : Event
    {
        public Order Order { get; set; }
        public bool Success { get; set; }
    }
}
