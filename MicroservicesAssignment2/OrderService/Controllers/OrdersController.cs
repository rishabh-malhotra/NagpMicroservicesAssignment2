using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonFlatFileDataStore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderService.Model;

namespace OrderService.Controllers
{
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private DataStore store;
        private readonly ILogger<OrdersController> _logger;
        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
            store = new DataStore("Data/orders.json");
        }

        [HttpGet,Route("api/orders/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var collection = store.GetCollection<Orders>();
                var orderDetails = collection.AsQueryable().ToList();
                return Ok(orderDetails);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}