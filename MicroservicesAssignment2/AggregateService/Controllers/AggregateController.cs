using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AggregateService.Controllers
{
    
    [ApiController]
    public class AggregateController : ControllerBase
    {
        [HttpGet,Route("api/GetOrderDetails")]
        public async Task<IActionResult> GetOrderDetails(int OrderId)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(Startup.UserServiceURL).GetAwaiter().GetResult();
            string result1 = await response.Content.ReadAsStringAsync();
            HttpResponseMessage responseFromOrderService = client.GetAsync(Startup.OrderServiceURL).GetAwaiter().GetResult();
            string result2 = await responseFromOrderService.Content.ReadAsStringAsync();
            return Ok(result1+result2);
            //GetAsync("localhost:61579/api/Users").Result;
        }   
    }
}