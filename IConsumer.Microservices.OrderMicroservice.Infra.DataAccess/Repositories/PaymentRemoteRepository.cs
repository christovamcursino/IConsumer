using IConsumer.Microservices.Common.Domain.Services;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.PaymentAggregate;
using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.Microservices.OrderMicroservice.Infra.DataAccess.Repositories
{
    public class PaymentRemoteRepository : IPaymentRepository
    {
        private ISerializerService _serializerService;

        private static string _baseUrl = "https://iconsumer-ccursino-paymentmicroservice.azurewebsites.net/api/payment";

        public PaymentRemoteRepository(ISerializerService serializerService)
        {
            _serializerService = serializerService;
        }

        public async Task<InvoiceDto> CreatePaymentAsync(InvoiceDto invoice)
        {
            var token = GetToken();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);

            var invoiceSerialized = _serializerService.Serialize(invoice);
            var httpContent = new StringContent(invoiceSerialized, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(_baseUrl, httpContent);

            var serializedInvoice = result.Content.ReadAsStringAsync().Result;
            var paidInvoice = _serializerService.Deserialize<InvoiceDto>(serializedInvoice);

            return paidInvoice;
        }

        private string GetToken()
        {
            var client = new HttpClient();
            var response = client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = "https://iconsumer-ccursino-iam-microservice-identity.azurewebsites.net/connect/token",

                ClientId = "IConsumerOrderMicroservice_ClientId"
            }).Result;

            return response.AccessToken;
        }
    }
}
