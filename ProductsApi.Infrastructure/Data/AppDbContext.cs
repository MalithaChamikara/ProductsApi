using Microsoft.EntityFrameworkCore;
using ProductsApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsApi.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories  => Set<Category>();
        public DbSet<Product> Products => Set<Product>();

        public DbSet<ProductImage> ProductImages => Set<ProductImage>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Category
            modelBuilder.Entity<Category>(e =>
            {
                e.HasKey(c => c.Id);
                e.Property(c => c.Name).IsRequired().HasMaxLength(100);
                e.Property(c => c.Slug).IsRequired().HasMaxLength(100);
                e.HasIndex(c => c.Slug).IsUnique();
            });

            // Product
            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey(p => p.Id);
                e.Property(p => p.Title).IsRequired().HasMaxLength(100);
                e.Property(p => p.Price).HasPrecision(10, 2);
                e.Property(p => p.ThumbnailUrl).HasMaxLength(500);
                e.Property(P => P.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

                // Relationships Product -> Category
                e.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Product Image
            modelBuilder.Entity<ProductImage>(e =>
            {
                e.HasKey(i => i.Id);
                e.Property(i => i.ImageUrl).IsRequired().HasMaxLength(500);

                // Relationships Image -> Product
                e.HasOne(i => i.Product)
                    .WithMany(p => p.Images)
                    .HasForeignKey(i => i.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Feed data to the database tables when application starts
            SeedData(modelBuilder);
            
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Slug = "electronics" },
                new Category { Id = 2, Name = "Clothing", Slug = "clothing" },
                new Category { Id = 3, Name = "Sports", Slug = "sports" }

            );

            modelBuilder.Entity<Product>().HasData(

                new Product { Id = 1, Title = "Headphones", Price = 79.99m, CategoryId = 1, ThumbnailUrl = "https://buyabans.com/cdn-cgi/imagedelivery/OgVIyabXh1YHxwM0lBwqgA/product/10342/new_projehjau_uat.png/public", Description = "High quality headphones with noise cancelling.", CreatedAt = new DateTime(2026, 4, 4, 0, 0, 0, DateTimeKind.Utc) },
                new Product { Id = 2, Title = "Keyboard", Price = 129.99m, CategoryId = 1, ThumbnailUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRhhSQ3LB8lbays7c9rWR4qfpTFWQw_iw7lew&s", Description = "keyboard with blue switches.", CreatedAt = new DateTime(2026, 4, 4, 0, 0, 0, DateTimeKind.Utc) },
                new Product { Id = 3, Title = "Shoes", Price = 59.99m, CategoryId = 2, ThumbnailUrl = "https://cdn.shopify.com/s/files/1/2997/9866/files/ff8c627fe9b5511d49db50c11273d5996c6ef23d7a9c4377cd2ce3800f0920e9.jpg?v=1773832197", Description = "Running shoes for all terrains.", CreatedAt = new DateTime(2026, 4, 4, 0, 0, 0, DateTimeKind.Utc) },
                new Product { Id = 4, Title = "Cricket Bat", Price = 24.99m, CategoryId = 3, ThumbnailUrl = "https://m.media-amazon.com/images/I/317VTY6RngL._AC_UF1000,1000_QL80_.jpg", Description = "High quality cricket bat with pure travelling", CreatedAt = new DateTime(2024, 4, 4, 0, 0, 0, DateTimeKind.Utc) },
                new Product { Id = 5, Title = "Smart Watch", Price = 199.99m, CategoryId = 1, ThumbnailUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTalc59BAZBZhe1bVgnRu45IwAbb-cLO4DVBQ&s", Description = "Fitness tracking smart watch with heart rate monitor.", CreatedAt = new DateTime(2024, 4, 4, 0, 0, 0, DateTimeKind.Utc) }

                
            );
        }

    }
}
