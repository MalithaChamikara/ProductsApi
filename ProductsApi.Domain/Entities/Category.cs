using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsApi.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty ;

        // one category can  have multiple products
        // one-to-many relationship
        public ICollection<Product> Products {  get; set; } = new List<Product>();

    }
}
