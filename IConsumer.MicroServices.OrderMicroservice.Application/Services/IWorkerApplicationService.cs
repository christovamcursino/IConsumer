using IConsumer.Microservices.OrderMicroservice.Application.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.MicroServices.OrderMicroservice.Application.Services
{
    public interface IWorkerApplicationService
    {
        Task ProcessOrderAsync(ProcessOrderCommand processOrderCommand);
    }
}
