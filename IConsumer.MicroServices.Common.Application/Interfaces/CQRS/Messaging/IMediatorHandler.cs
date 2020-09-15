using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.MicroServices.Common.Application.Interfaces.CQRS.Messaging
{
    public interface IMediatorHandler
    {
        Task<bool> EnqueueAsync<T>(T command, string queueName);
    }
}
