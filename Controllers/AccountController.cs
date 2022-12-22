using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase {

        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger) {
            _logger = logger;
        }

        [HttpGet(Name = "GetResponse")]
        public ActionResult Get() {
            return Ok();
        }
    }
}