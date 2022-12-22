using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.Models.DTOs;

public class OrderCreateDto {
    [Required]
    [DisplayName("deliveryTime")]
    public DateTime DeliveryTime { get; set; }

    [Required]
    [MinLength(1)]
    [DisplayName("address")]
    public String Address { get; set; } = "";
}