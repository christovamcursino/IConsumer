using IConsumer.Microservices.Common.Domain.Services;
using IConsumer.Microservices.Common.Infra.DataAccess.UoW;
using IConsumer.Microservices.Common.Infra.Helper;
using IConsumer.Microservices.Common.Infra.Messaging.Services;
using IConsumer.Microservices.OrderMicroservice.Application.CQRS.Commands;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.PaymentAggregate;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.ProductAggregate;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.StoreAggregate;
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
        private static DbContext _context = new OrderContext();

        private static IWorkerApplicationService workerApplicationService = new WorkerApplicationService(
            new OrderCommandHandler(
                new OrderService(new UnitOfWork(_context),
                    new OrderRepository(_context),
                    new OrderStatusService(new UnitOfWork(_context), new OrderTrackingRepository(_context)),
                    new StoreTableQueryService(new StoreTableMicroserviceQueryRepository(new SerializerService())),
                    new ProductQueryService(new ProductMicroserviceQueryRepository(new SerializerService())),
                    new PaymentService(new PaymentRemoteRepository(new SerializerService()))
                    )
                ), 
            new AzureServiceBusQueue());
        private static ISerializerService serializerService = new SerializerService();

        public static Task ProcessOrderCommandFunction([ServiceBusTrigger(ProcessOrderCommand.CommandQueueName)] string message, ILogger logger)
        {
            logger.LogInformation(message);

            Console.WriteLine("Chegou mensagem: " + message);

            var command = serializerService.Deserialize<ProcessOrderCommand>(message);
            
            workerApplicationService.ProcessOrderAsync(command);

            return Task.CompletedTask;
        }
    }
}
