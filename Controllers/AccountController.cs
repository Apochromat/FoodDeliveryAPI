using FoodDeliveryAPI.Models.DTOs;
using FoodDeliveryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryAPI.Controllers {
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase {
        private readonly ILogger<AccountController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IAccountService _accountService;
        

        public AccountController(ILogger<AccountController> logger, ApplicationDbContext context, IAccountService accountService) {
            _logger = logger;
            _context = context;
            _accountService = accountService;
        }

        /// <summary>
        /// Register new user.
        /// </summary>
        /// <returns></returns>
        /// <response code = "400" > Bad Request</response>
        /// <response code = "409" > If there is user with same email</response>
        /// <response code = "500" > Internal Server Error</response>
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<TokenResponse>> Register([FromBody] UserRegisterModel userRegisterModel) {
            try {
                return await _accountService.register(userRegisterModel);
            }
            catch (InvalidOperationException e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 400, title: e.Message);
            }
            catch (KeyNotFoundException e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 404, title: e.Message);
            }
            catch (ArgumentException e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 409, title: e.Message);
            }
            catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }

        /// <summary>
        /// Log in to the system.
        /// </summary>
        /// <returns></returns>
        /// <response code = "400" > Bad Request</response>
        /// <response code = "401" > If email or password are incorrect</response>
        /// <response code = "500" > Internal Server Error</response>
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TokenResponse>> Login([FromBody] LoginCredentials loginCredentials) {
            try {
                return await _accountService.login(loginCredentials);
            }
            catch (ArgumentException e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 401, title: e.Message);
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
        /// Log out system user.
        /// </summary>
        /// <returns></returns>
        /// <response code = "400" > Bad Request</response>
        /// <response code = "401" > If user unauthorized</response>
        /// <response code = "500" > Internal Server Error</response>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("logout")]
        public async Task<ActionResult<Response>> Logout() {
            try {
                return await _accountService.logout(Request.Headers["Authorization"]);
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
        /// Get user profile.
        /// </summary>
        /// <returns></returns>
        /// <response code = "401" > Unauthorized</response>
        /// <response code = "500" > Internal Server Error</response>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route("profile")]
        public async Task<ActionResult<UserDto>> GetAccountProfile() {
            try {
                return await _accountService.getProfile(User.Identity.Name);
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
        /// Edit user profile.
        /// </summary>
        /// <returns></returns>
        /// <response code = "400" > Bad Request</response>
        /// <response code = "401" > Unauthorized</response>
        /// <response code = "403" > Forbidden</response>
        /// <response code = "500" > Internal Server Error</response>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        [Route("profile")]
        public async Task<ActionResult> EditAccountProfile() {
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