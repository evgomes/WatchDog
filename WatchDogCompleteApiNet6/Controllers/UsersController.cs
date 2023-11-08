﻿using Microsoft.AspNetCore.Mvc;
using WatchDogCompleteApiNet6.Models;

namespace WatchDogCompleteApiNet6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult PostSignInAsync([FromBody] Login payload)
        {
            _logger.LogInformation("Generating user token...");
            return Ok(new { AccessToken = "test token" });
        }

        [HttpPut]
        public IActionResult PutSignInAsync([FromBody] Login payload)
        {
            _logger.LogInformation("Generating user token...");
            return Ok(new { AccessToken = "test token" });
        }

        [HttpPatch]
        public IActionResult PatchSignInAsync([FromBody] Login payload)
        {
            _logger.LogInformation("Generating user token...");
            return Ok(new { AccessToken = "test token" });
        }
    }
}