using Microsoft.EntityFrameworkCore;
using ProductsApi.Domain.Entities;
using ProductsApi.Domain.Interfaces;
using ProductsApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsApi.Infrastructure.Repositories
{
    public class ProductRepository(AppDbContext dbContext): IProductRepository
    {
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await dbContext.Products
             .Include(p => p.Category)
             .AsNoTracking()
             .OrderBy(p => p.Id)
             .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await dbContext.Products
            .Include(p => p.Category)
            .Include(p => p.Images.OrderBy(i => i.Order))
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(string slug)
        {
            return await dbContext.Products
                .Include(p => p.Category)
                .Where(p => p.Category.Slug == slug)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchAsync(String query)
        {
            var q = query.Trim().ToLower();
            return await dbContext.Products
                .Include(p => p.Category)
                .Where(p => p.Title.ToLower().Contains(q) || (p.Description != null && p.Description.ToLower().Contains(q)))
                .AsNoTracking()
                .ToListAsync();
        }



    }
}
