using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.Models.DTOs {
    public class DishBasketDto {
        [DisplayName("id")] public Guid Id { get; set; }

        [Required]
        [MinLength(1)]
        [DisplayName("name")]
        public String Name { get; set; } = "";

        [Required] [DisplayName("price")] public double Price { get; set; }
        [Required] [DisplayName("totalPrice")] public double TotalPrice { get; set; }
        [Required] [DisplayName("amount")] public int Amount { get; set; }
        [Url] [DisplayName("image")] public String? Image { get; set; }
    }
}