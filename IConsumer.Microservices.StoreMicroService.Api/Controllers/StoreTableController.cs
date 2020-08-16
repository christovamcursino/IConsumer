using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IConsumer.Microservices.StoreMicroservice.Domain.AggregatesModel.StoreAggregate;
using IConsumer.Microservices.StoreMicroService.Api.Controllers.Model;
using IConsumer.MicroServices.Common.Api;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IConsumer.Microservices.StoreMicroService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreTableController : CustomBaseController
    {
        private readonly IStoreService _storeService;

        public StoreTableController(IStoreService storeService)
        {
            _storeService = storeService;
        }


        // GET api/<StoreTableController>/5
        [HttpGet("{id}")]
        public StoreTable Get(Guid id)
        {
            return _storeService.GetStoreTableById(id);
        }

        // POST api/<Teste>
        [HttpPost("add-tables")]
        public void Post([FromBody] AddTableModel addTablesModel)
        {
            var result = _storeService.AddTablesToStore(addTablesModel.StoreId, addTablesModel.TablesAmount);
        }
    }
}
