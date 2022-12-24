﻿using System.ComponentModel.DataAnnotations;
using FoodDeliveryAPI.Models.Enums;

namespace FoodDeliveryAPI.Models;

public class User {
    [Key]
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();

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
}