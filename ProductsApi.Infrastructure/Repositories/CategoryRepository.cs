using Microsoft.EntityFrameworkCore;
using ProductsApi.Domain.Entities;
using ProductsApi.Domain.Interfaces;
using ProductsApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsApi.Infrastructure.Repositories
{
    public  class CategoryRepository(AppDbContext dbContext): ICategoryRepository
    {
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await dbContext.Categories.AsNoTracking().OrderBy(c => c.Name).ToListAsync();
        }
    }
}
