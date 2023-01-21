using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Models.DTOs;
using FoodDeliveryAPI.Models.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace FoodDeliveryAPI.Services {
    public class AccountService : IAccountService {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<AccountService> _logger;
        private readonly ApplicationDbContext _context;

        public AccountService(ILogger<AccountService> logger, ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        public async Task<TokenResponse> login(LoginCredentials loginCredentials) {
            var identity = await GetIdentity(loginCredentials.Email.ToLower(), loginCredentials.Password);
            if (identity == null) {
                throw new ArgumentException("Incorrect username or password");
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: JwtConfiguration.Issuer,
                audience: JwtConfiguration.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(JwtConfiguration.Lifetime)),
                signingCredentials: new SigningCredentials(JwtConfiguration.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new TokenResponse(encodedJwt, 
                identity.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value).SingleOrDefault(),
                Enum.Parse<RoleType>(identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).SingleOrDefault()));
        }

        public String logout(string JwtToken) {
            throw new NotImplementedException();
        }

        public async Task<TokenResponse> register(UserRegisterModel userRegisterModel) {
            if (await _userManager.FindByNameAsync(userRegisterModel.Email) != null)
                throw new ArgumentException("User with this email already exists");

            User user = new User(userRegisterModel);

            var result = await _userManager.CreateAsync(user, userRegisterModel.Password); // Создание нового пользователя в системе с указанными данными и введенным паролем
            if (result.Succeeded) // результат может быть успешным, а может также возникнуть ошибка, если был введен пароль, не отвечающий требованиям
            {
                // Если регистрация прошла успешно, авторизуем пользователя в системе.
                _logger.LogInformation("Successful register");
                return await login(new LoginCredentials { Email = userRegisterModel.Email, Password = userRegisterModel.Password });
            }
            // Если произошла ошибка, собираем все ошибки в одну строку и выбрасываем наверх исключение
            var errors = string.Join(", ", result.Errors.Select(x => x.Description));
            throw new InvalidOperationException(errors);
        }

        public String editProfile(Guid UserId, UserEditModel userEditModel) {
            throw new NotImplementedException();
        }

        public async Task<UserDto> getProfile(string email) {
            var user = await _userManager.FindByNameAsync(email);
            if (user == null) throw new KeyNotFoundException("User not found");

            return new UserDto(user);
        }

        private async Task<ClaimsIdentity?> GetIdentity(string email, string password) {
            var user = await _userManager.FindByNameAsync(email);
            if (user == null) {
                return null;
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded) return null;

            var claims = new List<Claim>{
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                };

            return new ClaimsIdentity(claims, "Token", ClaimTypes.Email, ClaimTypes.Role);
        }
    }
}
