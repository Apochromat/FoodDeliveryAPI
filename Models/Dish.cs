using System.ComponentModel.DataAnnotations;
using FoodDeliveryAPI.Models.Enums;

namespace FoodDeliveryAPI.Models;

public class Dish {
    [Key]
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public String Name { get; set; } = "";
    public String? Description { get; set; }

    [Required]
    public double Price { get; set; }
    public String? Image { get; set; }

    [Required]
    public Boolean Vegetarian { get; set; } = false;
    public double? CalculatedRating { get; set; }
    public List<Rating> RawRating { get; set; } = new List<Rating>();
    public DishCategory Category { get; set; }
    public List<Basket> Basket { get; set; } = new List<Basket>();
    public List<OrderDish> OrderDishes { get; set; } = new List<OrderDish>();
}