using System.ComponentModel;

namespace FoodDeliveryAPI.Models.DTOs;

public class TokenResponse {
    [DisplayName("token")] public String? Token { get; set; }
}