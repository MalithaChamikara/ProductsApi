using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsApi.Application.DTOs
{
    public record CategoryDto
    (
        int Id,
        string Name,
        string Slug
    );
    
}
