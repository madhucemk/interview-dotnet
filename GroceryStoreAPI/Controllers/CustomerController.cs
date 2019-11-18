using GroceryStoreAPI.Model;
using GroceryStoreAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerRepository;

        public CustomerController(ICustomer customerRepository)
        {
            _customerRepository = customerRepository;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            try
            {
                return Ok(_customerRepository.GetAllCustomers());
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
                return Ok(_customerRepository.GetCustomerById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/values/Bob
        [HttpGet("{name}")]
        public ActionResult<string> Get(string name)
        {
            try
            {
                return Ok(_customerRepository.GetCustomersByName(name));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult<string> Post([FromBody] Customer value)
        {
            try
            {
                return Ok(_customerRepository.SaveCustomer(value));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
