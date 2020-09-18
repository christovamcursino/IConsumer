using IConsumer.App.Common.Domain.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.App.Infra.DataAccess.Serializer
{
    public class SerializerService : ISerializerService
    {
        public T Deserialize<T>(string serializedObj)
        {
            return JsonConvert.DeserializeObject<T>(serializedObj);
        }

        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
