using GroceryStoreAPI.Model;
using GroceryStoreAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productRepository;

        public ProductController(IProduct productRepository)
        {
            _productRepository = productRepository;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return Ok(_productRepository.GetAllProducts());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        // GET api/values/5
        [HttpGet("{id:int}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                return Ok(_productRepository.GetProductById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/values/Bob
        [HttpGet("{name}")]
        public ActionResult<string> Get(string description)
        {
            try
            {
                return Ok(_productRepository.GetProductsByDescription(description));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult<string> Post([FromBody] Product value)
        {
            try
            {
                return Ok(_productRepository.SaveProduct(value));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
