using IConsumer.Microservices.Common.Domain.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.Common.Infra.Helper
{
    public class SerializerService : ISerializerService
    {
        public T Deserialize<T>(string serializedObj)
        {
            //FLURL alternativa ao Newtonsoft
            return JsonConvert.DeserializeObject<T>(serializedObj);
        }

        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
