using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.MicroServices.OrderMicroservice.OrderWorker
{
    public class Functions
    {
        private static IWorkerApplicationService workerApplicationService = new WorkerApplicationService(new OrderCommandHandler(new OrderService(new ProductQueryService(new ProductMicroserviceQueryRepository(new SerializerService())), new OrderRepository(new OrderContext()))), new AzureServiceBusQueue());
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
