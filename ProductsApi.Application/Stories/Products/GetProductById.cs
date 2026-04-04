using ProductsApi.Application.DTOs;
using ProductsApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsApi.Application.Stories.Products
{
    public class GetProductById(IProductRepository productRepo)
    {
        public async Task<ProductDetailDto?> ExecuteAsync(int id)
        {
            var product = await productRepo.GetByIdAsync(id);
            if(product == null) return null;

            return new ProductDetailDto(
            product.Id, product.Title, product.Description, product.Price,
            product.Category.Name, product.ThumbnailUrl,
            product.Images.OrderBy(i => i.Order).Select(i => i.ImageUrl));
        }
    }
}
