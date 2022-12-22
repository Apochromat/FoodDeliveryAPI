using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.Models {
    public class Rating {
        public Guid Id { get; set; } = Guid.NewGuid();
        public User User { get; set; }
        public Dish Dish { get; set; }
        public int RatingValue { get; set; }
    }
}
