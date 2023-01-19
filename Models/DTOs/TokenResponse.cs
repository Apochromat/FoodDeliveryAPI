using System.ComponentModel;

namespace FoodDeliveryAPI.Models.DTOs;

public class TokenResponse {

    public TokenResponse() { }
    public TokenResponse(string token, Guid guid) {
        this.Token = token;
        this.UserId = guid;
    }

    [DisplayName("token")] public String? Token { get; set; }
    [DisplayName("id")] public Guid? UserId { get; set; }
}