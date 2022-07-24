using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace ORM.EF
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(500);
                
                entity.Property(e => e.Name)
                    .HasMaxLength(200);

                entity.HasData(
                    new Product() { Name = "Apple tree", Description = "Apple", Height = 10, Length = 20, Weight = 30, Width = 40},
                    new Product() { Name = "Cat tree", Description = "Cat", Height = 1, Length = 2, Weight = 3, Width = 4 }
                );
            });
        }
    }
}
