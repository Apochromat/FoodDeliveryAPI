using System.ComponentModel;

namespace FoodDeliveryAPI.Models.DTOs {
    public class DishPagedListDto {
        [DisplayName("dishes")] public List<DishDto>? Dishes { get; set; }
        [DisplayName("pagination")] public PageInfoModel? Pagination { get; set; }
    }
}