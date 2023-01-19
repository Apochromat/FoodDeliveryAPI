using FoodDeliveryAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace FoodDeliveryAPI.Services {
    public interface IAccountService {
        Task<TokenResponse> register(UserRegisterModel userRegisterModel);
        Task<TokenResponse> login(LoginCredentials loginCredentials);
        String logout(String JwtToken);
        UserDto getProfile(Guid UserId);
        String editProfile(Guid UserId, UserEditModel userEditModel);

    }
}
