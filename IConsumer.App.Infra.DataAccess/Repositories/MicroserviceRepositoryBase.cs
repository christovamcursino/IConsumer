using IConsumer.App.Common.Domain.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace IConsumer.App.Infra.DataAccess.Repositories
{
    public class MicroserviceRepositoryBase
    {
        protected readonly string _token;
        protected readonly ISerializerService _serializerService;

        public MicroserviceRepositoryBase(string token, ISerializerService serializerService)
        {
            _token = token;
            _serializerService = serializerService;
        }

        protected HttpClient getHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + _token);
            return client;
        }
    }
}
