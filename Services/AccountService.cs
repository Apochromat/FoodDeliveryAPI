using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Models.DTOs;
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

        public String login(LoginCredentials loginCredentials) {
            throw new NotImplementedException();
        }

        public String logout(string JwtToken) {
            throw new NotImplementedException();
        }

        public async Task<TokenResponse> register(UserRegisterModel userRegisterModel) {
            foreach (User n_user in _context.Users) {
                if (n_user.Email.ToLower() == userRegisterModel.Email.ToLower())
                    throw new ArgumentException("User with this email already exists");
            }

            User user = new User(userRegisterModel);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Successful register");

            return new TokenResponse(JsonSerializer.Serialize(user));
            //return login(new LoginCredentials {Email = userRegisterModel.Email, Password = userRegisterModel.Password });
        }

        public String editProfile(Guid UserId, UserEditModel userEditModel) {
            throw new NotImplementedException();
        }

        public UserDto getProfile(Guid UserId) {
            throw new NotImplementedException();
        }
    }
}
