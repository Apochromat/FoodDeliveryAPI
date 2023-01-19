using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace FoodDeliveryAPI.Services {
    public class AccountService : IAccountService {
        private readonly ILogger<AccountService> _logger;
        private readonly ApplicationDbContext _context;

        public AccountService(ILogger<AccountService> logger, ApplicationDbContext context) {
            _logger = logger;
            _context = context;
        }

        public async Task<TokenResponse> login(LoginCredentials loginCredentials) {
            var identity = GetIdentity(loginCredentials.Email.ToLower(), loginCredentials.Password);
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

            return new TokenResponse(encodedJwt, new Guid(identity.Name));
        }

        public String logout(string JwtToken) {
            throw new NotImplementedException();
        }

        public async Task<TokenResponse> register(UserRegisterModel userRegisterModel) {
            if (_context.Users.Where(u => u.Email.ToLower() == userRegisterModel.Email.ToLower()).FirstOrDefault() != null)
                throw new ArgumentException("User with this email already exists");

            User user = new User(userRegisterModel);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Successful register");

            return await login(new LoginCredentials {Email = userRegisterModel.Email, Password = userRegisterModel.Password });
        }

        public String editProfile(Guid UserId, UserEditModel userEditModel) {
            throw new NotImplementedException();
        }

        public UserDto getProfile(Guid UserId) {
            User? user = _context.Users.Where(x => x.Id == UserId).FirstOrDefault();
            if (user == null) throw new KeyNotFoundException("User not found");

            return new UserDto(user);
        }

        private ClaimsIdentity? GetIdentity(string email, string password) {
            var user = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (user == null) {
                return null;
            }

            var claims = new List<Claim>{
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
                };

            return new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
