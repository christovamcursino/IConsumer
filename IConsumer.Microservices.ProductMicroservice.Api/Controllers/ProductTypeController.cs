using IConsumer.Microservices.ProcuctMicroservice.Domain.AggregatesModel.ProductAggregate;
using IConsumer.MicroServices.Common.Api;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IConsumer.Microservices.ProductMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : CustomBaseController
    {
        private readonly IProductTypeService _productTypeService;
        private readonly IProductService _productService;

        public ProductTypeController(IProductTypeService productTypeService, IProductService productService)
        {
            _productTypeService = productTypeService;
            _productService = productService;
        }

        // GET: api/<ProductTypeController>
        [HttpGet("store/{storeId}")]
        public IEnumerable<ProductType> GetProductTypes(Guid storeId)
        {
            return _productTypeService.GetProductTypes(storeId);
        }

        [HttpGet("store/{storeId}/menu")]
        public IEnumerable<ProductType> GetMenu(Guid storeId)
        {
            return _productService.GetMenu(storeId);
        }

        // GET api/<ProductTypeController>/5
        [HttpGet("{id}")]
        public ProductType Get(Guid id)
        {
            return _productTypeService.GetProductType(id);
        }

        // POST api/<ProductTypeController>
        [HttpPost]
        public ProductType Post([FromBody] ProductType productType)
        {
            var storeId = productType.StoreId;
            var result = _productTypeService.AddProductType(storeId, productType);
            return result;
        }

        // PUT api/<ProductTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<ProductTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
