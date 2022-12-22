using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.Models {
    public class OrderDish {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Order Order { get; set; }
        public Dish Dish { get; set; } 
        public int Amount { get; set; }
    }
}
