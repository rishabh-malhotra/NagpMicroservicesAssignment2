﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonFlatFileDataStore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserService.Model;

namespace UserService.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private DataStore store;
        private readonly ILogger<UsersController> _logger;
        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
            store = new DataStore("Data/users.json");
        }

        [HttpGet, Route("api/users/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var collection = store.GetCollection<Users>();
                var userDetails = collection.AsQueryable().FirstOrDefault();
                return Ok(userDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}