using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IConsumer.Microservices.CustomerMicroservice.Domain.AggregatesModel.CustomerAggregate;
using IConsumer.MicroServices.Common.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IConsumer.Microservices.CustomerMicroService.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : CustomBaseController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer Get(Guid id)
        {
            return _customerService.GetCustomer(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public Customer Post([FromBody] Customer customer)
        {
            bool validId = Guid.TryParse(User.FindFirst("sub")?.Value, out Guid customerId);
            if (!validId)
                throw new Exception("Invalid user id");

            return _customerService.AddCustomer(customerId, customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put( [FromBody] Customer customer)
        {
            bool validId = Guid.TryParse(User.FindFirst("sub")?.Value, out Guid customerId);
            if (!validId)
                throw new Exception("Invalid user id");

            _customerService.EditCustomer(customerId, customer);
        }

    }
}
