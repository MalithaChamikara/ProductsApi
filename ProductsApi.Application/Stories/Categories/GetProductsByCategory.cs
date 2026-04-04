using ProductsApi.Application.DTOs;
using ProductsApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsApi.Application.Stories.Categories
{
    public class GetProductsByCategory(IProductRepository productRepo)
    {
        public async Task<IEnumerable<ProductDto>> ExecuteAsync(string slug)
        {
            var products = await productRepo.GetByCategoryAsync(slug);
            return products.Select(p => new ProductDto(
           p.Id, p.Title, p.Price, p.Category.Name, p.ThumbnailUrl));
        }
    }
}
