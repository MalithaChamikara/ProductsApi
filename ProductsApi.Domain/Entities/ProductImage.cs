using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsApi.Domain.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public int Order { get; set; } = 0;

        // Foreign key
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
