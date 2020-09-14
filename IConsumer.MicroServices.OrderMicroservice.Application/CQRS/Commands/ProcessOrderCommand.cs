using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.OrderMicroservice.Application.CQRS.Commands
{
    public class ProcessOrderCommand : OrderCommand
    {
        public const string CommandQueueName = "process-order-command-queue";
        public override string QueueName => CommandQueueName;

        public ProcessOrderCommand()
        {
        }

        public ProcessOrderCommand(Order order)
        {
            Order = order;
        }
    }
}
