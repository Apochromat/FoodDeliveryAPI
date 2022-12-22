using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FoodDeliveryAPI.Models.Enums;

namespace FoodDeliveryAPI.Models.DTOs;

public class OrderDto {
    [DisplayName("id")] public Guid Id { get; set; }

    [Required]
    [DisplayName("deliveryTime")]
    public DateTime DeliveryTime { get; set; }

    [Required] [DisplayName("orderTime")] public DateTime OrderTime { get; set; }
    [Required] [DisplayName("status")] public OrderStatus Status { get; set; }
    [Required] [DisplayName("price")] public double Price { get; set; }
    [DisplayName("dishes")] public List<DishBasketDto>? Dishes { get; set; }

    [Required]
    [MinLength(1)]
    [DisplayName("address")]
    public String Address { get; set; } = "";
}