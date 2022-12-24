using FoodDeliveryAPI.Models.DTOs;
using FoodDeliveryAPI.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryAPI.Controllers {
    [ApiController]
    [Route("api/dish")]
    public class DishController : ControllerBase {
        private readonly ILogger<DishController> _logger;
        private readonly ApplicationDbContext _context;


        public DishController(ILogger<DishController> logger, ApplicationDbContext context) {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Get a list of dishies (menu)
        /// </summary>
        /// <param name="categories"> Dishies categories </param>
        /// <param name="vegetarian"> Get only vegetarian </param>
        /// <param name="sorting"> Dishes sort </param>
        /// <param name="page"> Dishies page</param>
        /// <returns></returns>
        /// <response code = "400" > Bad Request</response>
        /// <response code = "404" > If there is no dishes with these params or page is empty</response>
        /// <response code = "500" > Internal Server Error</response>
        [HttpGet]
        public async Task<ActionResult> GetDishies([FromQuery] List<DishCategory> categories, [FromQuery] Boolean vegetarian, [FromQuery] DishSorting sorting, [FromQuery] int page = 1) {
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
        /// Get information about concrete dish.
        /// </summary>
        /// <param name="id"> Dish id </param>
        /// <returns></returns>
        /// <response code = "404" > Not Found</response>
        /// <response code = "500" > Internal Server Error</response>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<DishDto>> GetDish(int id) {
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
        /// Check if user is able to set rating of the dish
        /// </summary>
        /// <param name="id"> Dish id </param>
        /// <returns></returns>
        /// <response code = "401" > Unauthorized</response>
        /// <response code = "403" > Forbidden</response>
        /// <response code = "404" > Not Found dish</response>
        /// <response code = "500" > Internal Server Error</response>
        [Authorize]
        [HttpGet]
        [Route("{id}/rating/check")]
        public async Task<ActionResult> DishRatingCheck(int id) {
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
        /// Set a rating for a dish
        /// </summary>
        /// <param name="id"> Dish id </param>
        /// <returns></returns>
        /// <response code = "400" > Bad Request</response>
        /// <response code = "401" > Unauthorized</response>
        /// <response code = "403" > Forbidden</response>
        /// <response code = "404" > Not Found dish</response>
        /// <response code = "500" > Internal Server Error</response>
        [Authorize]
        [HttpGet]
        [Route("{id}/rating")]
        public async Task<ActionResult> SetDishRating(int id) {
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