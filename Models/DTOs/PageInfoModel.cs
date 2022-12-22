using System.ComponentModel;

namespace FoodDeliveryAPI.Models.DTOs;

public class PageInfoModel {
    [DisplayName("size")] public int Size { get; set; }
    [DisplayName("count")] public int Count { get; set; }
    [DisplayName("current")] public int Current { get; set; }
}