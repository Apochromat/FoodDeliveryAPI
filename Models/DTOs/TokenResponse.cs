using System.ComponentModel;

namespace FoodDeliveryAPI.Models.DTOs;

public class TokenResponse {

    public TokenResponse() { }
    public TokenResponse(string token) {
        this.Token = token;
    }

    [DisplayName("token")] public String? Token { get; set; }
}