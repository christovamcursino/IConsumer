using IConsumer.Microservices.Common.Domain.Services;
using IConsumer.Microservices.Common.Infra.DataAccess.UoW;
using IConsumer.Microservices.Common.Infra.Helper;
using IConsumer.Microservices.Common.Infra.Messaging.Services;
using IConsumer.Microservices.OrderMicroservice.Application.CQRS.Commands;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using IConsumer.Microservices.OrderMicroservice.Infra.DataAccess.Context;
using IConsumer.Microservices.OrderMicroservice.Infra.DataAccess.Repositories;
using IConsumer.MicroServices.OrderMicroservice.Application.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.MicroServices.OrderMicroservice.OrderWorker
{
    public class Functions
    {
        private static DbContext context = new OrderContext();

        private static IWorkerApplicationService workerApplicationService = new WorkerApplicationService(
            new OrderCommandHandler(
                new OrderService(new UnitOfWork(context),
                    new OrderRepository(context),
                    new OrderStatusService(new UnitOfWork(context), new OrderTrackingRepository(context)))), 
            new AzureServiceBusQueue());
        private static ISerializerService serializerService = new SerializerService();

        //public Functions(IWorkerApplicationService workerApplicationService, ISerializerService serializerService)
        //{
        //    this.workerApplicationService = workerApplicationService;
        //    this.serializerService = serializerService;
        //}

        //[Singleton("ProductUpdateLock", SingletonScope.Host)]
        public static async Task ProcessOrderCommandFunction([ServiceBusTrigger(ProcessOrderCommand.CommandQueueName)] string message, ILogger logger)
        {
            logger.LogInformation(message);
            var command = serializerService.Deserialize<ProcessOrderCommand>(message);
            await workerApplicationService.ProcessOrderAsync(command);
        }
    }
}
