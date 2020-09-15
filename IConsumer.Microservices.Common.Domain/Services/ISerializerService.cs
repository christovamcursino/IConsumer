using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.Common.Domain.Services
{
    public interface ISerializerService
    {
        string Serialize<T>(T obj);
        T Deserialize<T>(string serializedObj);
    }
}
