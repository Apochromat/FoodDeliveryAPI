using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryAPI.Controllers {
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase {
        private readonly ILogger<OrderController> _logger;
        private readonly ApplicationDbContext _context;
        public OrderController(ILogger<OrderController> logger, ApplicationDbContext context) {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Get information about concrete order
        /// </summary>
        /// <param name="id"> Order id </param>
        /// <returns></returns>
        /// <response code = "401" > Unauthorized</response>
        /// <response code = "403" > Forbidden</response>
        /// <response code = "404" > Not Found</response>
        /// <response code = "500" > Internal Server Error</response>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetOrder(int id) {
            try {
                return Ok();
            }
            catch (KeyNotFoundException e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 404, title: e.Message);
            }
            catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }

        /// <summary>
        /// Get a list of orders
        /// </summary>
        /// <returns></returns>
        /// <response code = "401" > Unauthorized</response>
        /// <response code = "404" > Not Found</response>
        /// <response code = "500" > Internal Server Error</response>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetOrders() {
            try {
                return Ok();
            }
            catch (KeyNotFoundException e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 404, title: e.Message);
            }
            catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }

        /// <summary>
        /// Creating the order from the dishies in basket
        /// </summary>
        /// <returns></returns>
        /// <response code = "400" > Bad Request</response>
        /// <response code = "401" > Unauthorized</response>
        /// <response code = "403" > Forbidden</response>
        /// <response code = "500" > Internal Server Error</response>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<ActionResult> CreateOrder() {
            try {
                return Ok();
            }
            catch (KeyNotFoundException e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 404, title: e.Message);
            }
            catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }

        /// <summary>
        /// Confirm order delivery
        /// </summary>
        /// <param name="id"> Order id </param>
        /// <returns></returns>
        /// <response code = "400" > Bad Request</response>
        /// <response code = "401" > Unauthorized</response>
        /// <response code = "403" > Forbidden</response>
        /// <response code = "404" > Not Found</response>
        /// <response code = "500" > Internal Server Error</response>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("{id}/status")]
        public async Task<ActionResult> ConfirmOrderDelivery(int id) {
            try {
                return Ok();
            }
            catch (KeyNotFoundException e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 404, title: e.Message);
            }
            catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }
    }
}