using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsApi.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? ThumbnailUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign Key
        public int CategoryId {  get; set; }
        public Category Category { get; set; } = null!;

        // Procut images
        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();

    }
}
