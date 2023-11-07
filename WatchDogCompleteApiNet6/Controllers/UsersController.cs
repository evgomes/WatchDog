using Microsoft.AspNetCore.Mvc;
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
        public IActionResult SignInAsync([FromBody] Login payload)
        {
            _logger.LogInformation("Generating user token...");
            return Ok(new { AccessToken = "test token" });
        }
    }
}
