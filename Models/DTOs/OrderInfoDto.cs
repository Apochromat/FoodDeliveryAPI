using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FoodDeliveryAPI.Models.Enums;

namespace FoodDeliveryAPI.Models.DTOs;

public class OrderInfoDto {
    [DisplayName("id")] public Guid Id { get; set; }

    [Required]
    [DisplayName("deliveryTime")]
    public DateTime DeliveryTime { get; set; }

    [Required] [DisplayName("orderTime")] public DateTime OrderTime { get; set; }
    [Required] [DisplayName("status")] public OrderStatus Status { get; set; }
    [Required] [DisplayName("price")] public double Price { get; set; }
}