using FoodDeliveryAPI.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace FoodDeliveryAPI.Models {
    public class Role : IdentityRole<Guid> {
        public RoleType Type { get; set; }
        public ICollection<UserRole> Users { get; set; }
    }

}
