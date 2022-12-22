using FoodDeliveryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAPI;

public class ApplicationDbContext : DbContext {
    public ApplicationDbContext() : base() {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<OrderDish> OrderDishes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<User>().HasKey(x => x.Id);
        modelBuilder.Entity<Dish>().HasKey(x => x.Id);
        modelBuilder.Entity<Order>().HasKey(x => x.Id);
        modelBuilder.Entity<Basket>().HasKey(x => x.Id);
        modelBuilder.Entity<Rating>().HasKey(x => x.Id);
        modelBuilder.Entity<OrderDish>().HasKey(x => x.Id);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseMySql("server=79.137.199.238;user=deliveryfood;password=#J9c&!wjG4q@75;database=deliveryfood;",
            new MySqlServerVersion(new Version(8, 0, 31)));
    }
}