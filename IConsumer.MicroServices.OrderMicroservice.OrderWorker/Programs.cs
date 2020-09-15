using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.MicroServices.OrderMicroservice.OrderWorker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new HostBuilder();
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<Functions, Functions>();
                services.AddSingleton<IMediatorHandler, AzureServiceBusQueue>();
                services.AddSingleton<IProductQueryRepository, ProductMicroserviceQueryRepository>();
                services.AddSingleton<DbContext, OrderContext>();
                services.AddSingleton<IOrderRepository, OrderRepository>();
                services.AddSingleton<IOrderService, OrderService>();
                services.AddSingleton<IProductQueryService, ProductQueryService>();
                services.AddSingleton<ISerializerService, SerializerService>();
                services.AddSingleton<IWorkerApplicationService, WorkerApplicationService>();
            }).ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddServiceBus(sbOptions =>
                {
                    sbOptions.ConnectionString = Resources.ServiceBusConnectionString;
                    sbOptions.MessageHandlerOptions.AutoComplete = true;
                    sbOptions.MessageHandlerOptions.MaxConcurrentCalls = 16;
                });
            });
            var host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}
