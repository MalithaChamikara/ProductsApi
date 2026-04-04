using ProductsApi.Application.DTOs;
using ProductsApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsApi.Application.Stories.Products
{
    public  class SearchProducts(IProductRepository productRepo)
    {
        public async Task<IEnumerable<ProductDto>> ExecuteAsync(string query)
        {
            var products = await productRepo.SearchAsync(query);
            return products.Select(p => new ProductDto(
            p.Id, p.Title, p.Price, p.Category.Name, p.ThumbnailUrl));
        }
    }
}
