using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using IConsumer.MicroServices.Common.Api;
using IConsumer.MicroServices.OrderMicroservice.Application.Services;
using IConsumer.MicroServices.OrderMicroservice.Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IConsumer.MicroServices.OrderMicroservice.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : CustomBaseController
    {
        private readonly IApiApplicationService _applicationService;

        public OrderController(IApiApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        // GET: api/<OrderController>
        [HttpGet("new-orders")]
        public async Task<IEnumerable<Order>> GetNewOrders()
        {
            bool validId = Guid.TryParse(User.FindFirst("sub")?.Value, out Guid storeId);
            if (!validId)
                throw new Exception("Invalid user id");

            return await _applicationService.GetStoreNewOrders(storeId);
        }

        // GET api/<OrderController>/5
        [HttpGet("{orderId}")]
        public async Task<Order> Get(Guid orderId)
        {
            return await _applicationService.GetOrder(orderId);
        }

        // POST api/<OrderController>
        [HttpPost("table/{tableId}")]
        public async Task<Order> PostOrder(Guid tableId, [FromBody] CreateOrderViewModel orderViewModel)
        {
            bool validId = Guid.TryParse(User.FindFirst("sub")?.Value, out Guid customerId);
            if (!validId)
                throw new Exception("Invalid user id");

            var order = await _applicationService.CreateOrderAsync(customerId, tableId, orderViewModel);

            //return CreatedAtAction("GetOrder", new { id = order.Id }, order);
            return order;
        }

        // PUT api/<OrderController>/5
        [HttpPut("{orderId}/status")]
        public async Task Put(Guid orderId, [FromBody] ChangeStatusViewModel orderStatus)
        {
            bool validId = Guid.TryParse(User.FindFirst("sub")?.Value, out Guid storeId);
            if (!validId)
                throw new Exception("Invalid user id");

            await _applicationService.ChangeOrderStatus(storeId, orderId, orderStatus);
        }
    }
}
