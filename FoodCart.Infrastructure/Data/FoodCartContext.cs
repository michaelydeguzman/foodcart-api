using FoodCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodCart.Infrastructure.Data
{
    public class FoodCartContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public FoodCartContext(DbContextOptions<FoodCartContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
        }
    }
}