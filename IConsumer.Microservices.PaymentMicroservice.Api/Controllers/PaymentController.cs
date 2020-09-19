using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IConsumer.Microservices.PaymentMicroservice.Api.Model;
using IConsumer.Microservices.PaymentMicroservice.Domain.AggregatesModel.InvoicetAggregate;
using IConsumer.MicroServices.Common.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IConsumer.Microservices.PaymentMicroservice.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : CustomBaseController
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // POST api/<PaymentController>
        [HttpPost]
        public InvoiceViewModel Post([FromBody] InvoiceViewModel invoice)
        {
            var result = _paymentService.MockInvoicePayment(invoice.CustomerId, invoice.OrderId, invoice.InvoiceTotal);
            invoice.Id = result.Id;
            return invoice;
        }

    }
}
