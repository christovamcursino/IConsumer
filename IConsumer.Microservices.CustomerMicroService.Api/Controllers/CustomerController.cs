using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IConsumer.Microservices.CustomerMicroservice.Domain.AggregatesModel.CustomerAggregate;
using IConsumer.MicroServices.Common.Api;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IConsumer.Microservices.CustomerMicroService.Api.Controllers
{
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
        public void Post([FromBody] Customer customer)
        {
            //TODO: O id virá do jwt
            _customerService.AddCustomer(Guid.NewGuid(), customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Customer customer)
        {
            _customerService.EditCustomer(Guid.NewGuid(), customer);
        }

    }
}
