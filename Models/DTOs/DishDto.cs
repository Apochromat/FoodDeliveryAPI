using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FoodDeliveryAPI.Models.Enums;

namespace FoodDeliveryAPI.Models.DTOs {
    public class DishDto {
        [DisplayName("id")] public Guid Id { get; set; }

        [Required]
        [MinLength(1)]
        [DisplayName("name")]
        public String Name { get; set; } = "";

        [DisplayName("description")] public String? Description { get; set; }
        [DisplayName("price")] [Required] public double Price { get; set; }
        [Url] [DisplayName("image")] public String? Image { get; set; }
        [DisplayName("vegetarian")] public Boolean Vegetarian { get; set; }
        [DisplayName("rating")] public double? Rating { get; set; }
        [DisplayName("category")] public DishCategory Category { get; set; }
    }
}