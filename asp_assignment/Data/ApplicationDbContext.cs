using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using asp_assignment.Models;

namespace asp_assignment.Data
{
  
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Souvenir> Souvenirs { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderSouvenir> OrderSouvenirs { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Souvenir>().ToTable("Souvenir");
            builder.Entity<Supplier>().ToTable("Supplier");
            builder.Entity<Category>().ToTable("Category");
            builder.Entity<Order>().ToTable("Order");
            builder.Entity<OrderSouvenir>().ToTable("OrderSouvenir");
            builder.Entity<CartItem>().ToTable("CartItem");

            builder.Entity<OrderSouvenir>().HasOne(p => p.Order).WithMany(o => o.OrderSouvenirs).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<OrderSouvenir>().HasOne(p => p.Souvenir).WithMany(o => o.OrderSouvenirs).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Souvenir>().HasOne(s=>s.Category).WithMany(c=>c.Souvenirs).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Souvenir>().HasOne(s => s.Supplier).WithMany(s => s.Souvenirs).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Order>().HasOne(o=>o.User).WithMany(u=>u.Orders).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<CartItem>().HasOne(c => c.Souvenir).WithMany(s => s.CartItems).OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<asp_assignment.Models.ShoppingCart> ShoppingCart { get; set; }
    }
}
