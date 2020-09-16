using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IConsumer.Microservices.StoreMicroservice.Domain.AggregatesModel.StoreAggregate;
using IConsumer.MicroServices.Common.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IConsumer.Microservices.StoreMicroService.Api.Controllers
{
    [Authorize]
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
        [HttpGet]
        public Store Get(Guid id)
        {
            bool validId = Guid.TryParse(User.FindFirst("sub")?.Value, out Guid storeId);
            if (!validId)
                throw new Exception("Invalid user id");

            return _storeService.GetStore(storeId);
        }

        // POST api/<StoreController>
        [HttpPost]
        public Store Post([FromBody] Store store)
        {
            bool validId = Guid.TryParse(User.FindFirst("sub")?.Value, out Guid storeId);
            if (!validId)
                throw new Exception("Invalid user id");

            var result = _storeService.AddStore(storeId, store);
            return result;
        }

        // PUT api/<StoreController>/5
        [HttpPut]
        public void Put([FromBody] Store store)
        {
            bool validId = Guid.TryParse(User.FindFirst("sub")?.Value, out Guid storeId);
            if (!validId)
                throw new Exception("Invalid user id");

            _storeService.EditStore(storeId, store);
        }


    }
}
