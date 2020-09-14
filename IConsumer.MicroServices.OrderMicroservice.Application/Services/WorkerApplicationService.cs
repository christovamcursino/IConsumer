using IConsumer.Microservices.OrderMicroservice.Application.CQRS.Commands;
using IConsumer.Microservices.OrderMicroservice.Application.CQRS.Events;
using IConsumer.MicroServices.Common.Application.Interfaces.CQRS.Messaging;
using IConsumer.MicroServices.OrderMicroservice.Application.CQRS.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.MicroServices.OrderMicroservice.Application.Services
{
    public class WorkerApplicationService : IWorkerApplicationService
    {
        private readonly IOrderCommandHandler _orderCommandHandler;
        private readonly IMediatorHandler _bus;

        public WorkerApplicationService(IOrderCommandHandler orderCommandHandler, IMediatorHandler bus)
        {
            this._orderCommandHandler = orderCommandHandler;
            this._bus = bus;
        }

        public async Task ProcessOrderAsync(ProcessOrderCommand processOrderCommand)
        {
            var commandHandlerSuccess = await _orderCommandHandler.HandleAsync(processOrderCommand);
            var orderProcessedEvent = new OrderProcessedEvent(processOrderCommand.Order);
            orderProcessedEvent.Success = true;

            if (!commandHandlerSuccess)
                orderProcessedEvent.Success = false;

            await _bus.EnqueueAsync(orderProcessedEvent, OrderProcessedEvent.EventQueueName);
        }
    }
}
