using ProductsApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsApi.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
    }
}   
