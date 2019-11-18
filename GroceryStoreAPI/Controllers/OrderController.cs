using GroceryStoreAPI.Model;
using GroceryStoreAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _OrderRepository;

        public OrderController(IOrder OrderRepository)
        {
            _OrderRepository = OrderRepository;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            try
            {
                return Ok(_OrderRepository.GetAllOrders());
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
                return Ok(_OrderRepository.GetOrderById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/values/5
        [Route("Customer/{id}")]
        public ActionResult<string> GetByCutomer(int id)
        {
            try
            {
                return Ok(_OrderRepository.GetOrdersByCustomer(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/values/Bob
        [HttpGet("{date:DateTime}")]
        public ActionResult<string> Get(DateTime date)
        {
            try
            {
                return Ok(_OrderRepository.GetOrdersByDate(date));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}
