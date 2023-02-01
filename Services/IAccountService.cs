using FoodDeliveryAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace FoodDeliveryAPI.Services {
    public interface IAccountService {
        Task<TokenResponse> register(UserRegisterModel userRegisterModel);
        Task<TokenResponse> login(LoginCredentials loginCredentials);
        Task<Response> logout(String JwtToken);
        Task<UserDto> getProfile(string email);
        String editProfile(Guid UserId, UserEditModel userEditModel);

    }
}
