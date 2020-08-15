using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IConsumer.Microservices.StoreMicroservice.Domain.AggregatesModel.StoreAggregate;
using IConsumer.MicroServices.Common.Api;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IConsumer.Microservices.StoreMicroService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : CustomBaseController
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        // GET api/<StoreController>/5
        [HttpGet("{id}")]
        public Store Get(Guid id)
        {
            return _storeService.GetStore(id);
        }

        // POST api/<StoreController>
        [HttpPost]
        public void Post([FromBody] Store store)
        {
            //TODO: o id vira do IAM
            Guid id = Guid.NewGuid();
            _storeService.AddStore(id, store);
        }

        // PUT api/<StoreController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Store store)
        {
            _storeService.EditStore(id, store);
        }


    }
}
