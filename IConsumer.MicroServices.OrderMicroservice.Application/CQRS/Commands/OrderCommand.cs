using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using IConsumer.MicroServices.Common.Application.Interfaces.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.Application.CQRS.Commands
{
    public abstract class OrderCommand : Command
    {
        public Order Order { get; set; }
    }
}
