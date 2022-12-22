using System.ComponentModel.DataAnnotations;
using FoodDeliveryAPI.Models.Enums;

namespace FoodDeliveryAPI.Models;

public class Order {
    [Key]
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public DateTime DeliveryTime { get; set; }

    [Required]
    public DateTime OrderTime { get; set; } = DateTime.Now;
    public OrderStatus Status { get; set; } = OrderStatus.InProcess;
    public double Price { get; set; }

    [Required]
    public String Address { get; set; } = "";
    public List<OrderDish> OrderDishes { get; set; } = new List<OrderDish>();
}