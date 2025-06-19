using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Discount.Grpc.Data
{
    public class DiscountContext : DbContext
    {
        public DbSet<Coupon> Coupon {  get; set; }

        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { Id = 1, ProductName = "iPhone X", Description = "Latest Apple iPhone", Amount = 200 },
                new Coupon { Id = 2, ProductName = "Samsung Galaxy S21", Description = "Flagship Samsung phone", Amount = 150 },
                new Coupon { Id = 3, ProductName = "MacBook Pro", Description = "Apple MacBook with M1 chip", Amount = 300 },
                new Coupon { Id = 4, ProductName = "Dell XPS 13", Description = "Premium Windows laptop", Amount = 250 },
                new Coupon { Id = 5, ProductName = "Sony WH-1000XM4", Description = "Noise-canceling headphones", Amount = 100 },
                new Coupon { Id = 6, ProductName = "Apple Watch Series 7", Description = "Smartwatch with fitness tracking", Amount = 120 },
                new Coupon { Id = 7, ProductName = "iPad Pro", Description = "Apple iPad with M1 chip", Amount = 180 },
                new Coupon { Id = 8, ProductName = "Nintendo Switch", Description = "Popular gaming console", Amount = 90 },
                new Coupon { Id = 9, ProductName = "Bose SoundLink", Description = "Bluetooth speaker with deep bass", Amount = 80 },
                new Coupon { Id = 10, ProductName = "Google Pixel 6", Description = "Google's latest flagship phone", Amount = 160 }
            );
        }

    }
}
