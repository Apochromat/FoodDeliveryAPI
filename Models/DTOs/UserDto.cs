using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FoodDeliveryAPI.Models.Enums;

namespace FoodDeliveryAPI.Models.DTOs;

public class UserDto {
    [DisplayName("id")] public Guid Id { get; set; }

    [Required]
    [RegularExpression(@"^[а-яА-Яa-zA-Z0-9\-_ ]+$")]
    [MinLength(1)]
    [MaxLength(64)]
    [DisplayName("fullName")]
    public String FullName { get; set; } = "";

    [DisplayName("birthDate")] public DateTime? BirthDate { get; set; }

    [Required] [DisplayName("gender")] public Gender Gender { get; set; }

    [DisplayName("address")] public String? Address { get; set; }

    [EmailAddress] [DisplayName("email")] public String? Email { get; set; }

    [Phone] [DisplayName("phoneNumber")] public String? PhoneNumber { get; set; }

    public UserDto() { }
    public UserDto(User user) { 
        Id = user.Id;
        FullName = user.FullName;
        BirthDate = user.BirthDate;
        Gender = user.Gender;
        Address = user.Address;
        Email = user.Email;
        PhoneNumber = user.PhoneNumber;
    }

}