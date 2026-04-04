using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsApi.Application.DTOs
{
    public record ProductDto
    (
        int Id,
        string Title,
        decimal Price,
        string Category,
        string? ThumbnailUrl
    );
}
