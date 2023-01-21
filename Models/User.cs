using System.ComponentModel.DataAnnotations;
using FoodDeliveryAPI.Models.DTOs;
using FoodDeliveryAPI.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace FoodDeliveryAPI.Models;

public class User : IdentityUser<Guid> {

    public User() { }
    public User(UserRegisterModel userRegisterModel) {
        this.FullName = userRegisterModel.FullName;
        this.UserName = userRegisterModel.Email;
        this.Email = userRegisterModel.Email;
        this.Address = userRegisterModel.Address;
        this.BirthDate = userRegisterModel.BirthDate;
        this.Gender = userRegisterModel.Gender;
        this.PhoneNumber = userRegisterModel.PhoneNumber;
    }

    [Required]
    public RoleType Role { get; set; } = RoleType.User;

    [Required]
    public String FullName { get; set; } = "";

    [Required]
    public String Password { get; set; } = "";

    [Required]
    public String? Email { get; set; }
    public String? Address { get; set; }

    [Required]
    public DateTime? BirthDate { get; set; }

    [Required]
    public Gender Gender { get; set; }
    public String? PhoneNumber { get; set; }
    public List<Rating> RawRating { get; set; } = new List<Rating>();
    public List<Basket> Basket { get; set; } = new List<Basket>();
    public List<Order> Orders { get; set; } = new List<Order>();

    public ICollection<UserRole> Roles { get; set; }
}