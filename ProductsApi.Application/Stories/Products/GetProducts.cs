using ProductsApi.Application.DTOs;
using ProductsApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsApi.Application.Stories.Products
{
    public class GetProducts(IProductRepository productRepo)
    {
        public async Task<IEnumerable<ProductDto>> ExecuteAsync()
        {
            var products = await productRepo.GetAllAsync();
            return products.Select(p => new ProductDto(p.Id, p.Title, p.Price, p.Category.Name, p.ThumbnailUrl));
        }
    }
}
