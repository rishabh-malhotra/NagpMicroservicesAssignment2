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
        [HttpGet,Route("api/GetOrderDetails/{id}")]
        public async Task<IActionResult> GetOrderDetails(int Id)
        {
            string userUrl= Environment.GetEnvironmentVariable("USER_URL");
            string orderUrl = Environment.GetEnvironmentVariable("ORDER_URL");

            try
            {
                Dictionary<string, object> finalResponse = new Dictionary<string, object>();
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage responseFromUserService = client.GetAsync(String.Concat(userUrl,"/"+Id)).GetAwaiter().GetResult();
                    string userDetailsString = await responseFromUserService.Content.ReadAsStringAsync();
                    object userDetailsObject = JsonSerializer.Deserialize<object>(userDetailsString);
                    finalResponse.Add("userDetails", userDetailsObject);

                    HttpResponseMessage responseFromOrderService = client.GetAsync(String.Concat(orderUrl, "/" + Id)).GetAwaiter().GetResult();
                    string orderDetailsString = await responseFromOrderService.Content.ReadAsStringAsync();
                    object orderDetailsObject = JsonSerializer.Deserialize<object>(orderDetailsString);
                    finalResponse.Add("orders", orderDetailsObject);
                }
                return Ok(finalResponse);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }   
    }
}