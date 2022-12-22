using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryAPI.Controllers {
    [Authorize]
    [ApiController]
    [Route("api/basket")]
    public class BasketController : ControllerBase {
        private readonly ILogger<BasketController> _logger;

        public BasketController(ILogger<BasketController> logger) {
            _logger = logger;
        }

        /// <summary>
        /// Get user cart
        /// </summary>
        /// <returns></returns>
        /// <response code = "401" > Unauthorized</response>
        /// <response code = "403" > Forbidden</response>
        /// <response code = "404" > Not Found</response>
        /// <response code = "500" > Internal Server Error</response>
        [HttpGet]
        public async Task<ActionResult> GetCart() {
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
        /// Add dish to cart
        /// </summary>
        /// <param name="dishId"> Dish id </param>
        /// <returns></returns>
        /// <response code = "401" > Unauthorized</response>
        /// <response code = "403" > Forbidden</response>
        /// <response code = "404" > Not Found</response>
        /// <response code = "500" > Internal Server Error</response>
        [Authorize]
        [HttpPost]
        [Route("dish/{dishId}")]
        public async Task<ActionResult> AddDishBasket(int dishId) {
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
        /// Decrease the number of dishes in the cart(if increase = true), or remove the dish completely(increase = false)
        /// </summary>
        /// <param name="dishId"> Dish id </param>
        /// <param name="increase"> Remove only one </param>
        /// <returns></returns>
        /// <response code = "401" > Unauthorized</response>
        /// <response code = "403" > Forbidden</response>
        /// <response code = "404" > Not Found</response>
        /// <response code = "500" > Internal Server Error</response>
        [Authorize]
        [HttpDelete]
        [Route("dish/{dishId}")]
        public async Task<ActionResult> RemoveDishBasket(int dishId, Boolean increase) {
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