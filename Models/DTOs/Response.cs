using System.ComponentModel;

namespace FoodDeliveryAPI.Models.DTOs;

public class Response {
    [DisplayName("status")] public String? Status { get; set; }
    [DisplayName("message")] public String? Message { get; set; }

    public Response(string? status, string? message) {
        Status = status;
        Message = message;
    }
    public Response() { }
}