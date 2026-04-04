using ProductsApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsApi.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetIdByAsync(int id);

        Task<IEnumerable<Product>> GetByCategoryAsync(string slug);

        Task<IEnumerable<Product>> SearchAsync(string query);
    }
}
