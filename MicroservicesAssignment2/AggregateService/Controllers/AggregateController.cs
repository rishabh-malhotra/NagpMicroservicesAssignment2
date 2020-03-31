using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
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
            Dictionary<string, object> finalResponse = new Dictionary<string, object>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(Startup.UserServiceURL).GetAwaiter().GetResult();
            string result1 = await response.Content.ReadAsStringAsync();
            object res1 = JsonSerializer.Deserialize<object>(result1);
            finalResponse.Add("userDetails", res1);
            HttpResponseMessage responseFromOrderService = client.GetAsync(Startup.OrderServiceURL).GetAwaiter().GetResult();
            string result2 = await responseFromOrderService.Content.ReadAsStringAsync();
            object res2 = JsonSerializer.Deserialize<object>(result2);
            finalResponse.Add("orders", res2);
            return Ok(finalResponse);
            //GetAsync("localhost:61579/api/Users").Result;
        }   
    }
}