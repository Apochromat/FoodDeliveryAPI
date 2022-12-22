using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.Models {
    public class Basket {
        public Guid Id { get; set; } = Guid.NewGuid();
        public User User { get; set; }
        public Dish Dish { get; set; }
        public int Amount { get; set; }
    }
}
