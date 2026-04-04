using ProductsApi.Application.DTOs;
using ProductsApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsApi.Application.Stories.Categories
{
    public class GetCategories(ICategoryRepository categoryRepo)
    {
        public async Task<IEnumerable<CategoryDto>> ExecuteAsync()
        {
            var categories = await categoryRepo.GetAllAsync();
            return categories.Select(c => new CategoryDto(c.Id, c.Name,c.Slug));
        }
    }
}
