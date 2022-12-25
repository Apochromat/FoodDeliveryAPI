using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FoodDeliveryAPI.Models.Enums;

namespace FoodDeliveryAPI.Models.DTOs;

public class UserRegisterModel {
    [Required]
    [RegularExpression(@"^[а-яА-Яa-zA-Z0-9\-_ ]+$")]
    [MinLength(1)]
    [MaxLength(64)]
    [DisplayName("fullName")]
    public String FullName { get; set; } = "";

    [Required]
    [RegularExpression(@"^[a-zA-Z0-9\-_!@#№$%^&?*+=(){}[\]<>~]+$")]
    [MinLength(8)]
    [MaxLength(64)]
    [DisplayName("password")]
    public String Password { get; set; } = "";

    [Required]
    [EmailAddress]
    [DisplayName("email")]
    public String? Email { get; set; }

    [DisplayName("address")] public String? Address { get; set; }

    [DisplayName("birthDate")] public DateTime? BirthDate { get; set; }

    [Required][DisplayName("gender")] public Gender Gender { get; set; }

    [Phone] [DisplayName("phoneNumber")] public String? PhoneNumber { get; set; }
}