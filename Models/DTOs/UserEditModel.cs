using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FoodDeliveryAPI.Models.Enums;

namespace FoodDeliveryAPI.Models.DTOs;

public class UserEditModel {
    [Required]
    [RegularExpression(@"^[а-яА-Яa-zA-Z0-9\-_ ]+$")]
    [MinLength(1)]
    [MaxLength(64)]
    [DisplayName("fullName")]
    public String FullName { get; set; } = "";

    [DisplayName("birthDate")] public DateTime? BirthDate { get; set; }

    [Required] [DisplayName("gender")] public Gender Gender { get; set; }

    [DisplayName("address")] public String? Address { get; set; }

    [Phone] [DisplayName("phoneNumber")] public String? PhoneNumber { get; set; }
}