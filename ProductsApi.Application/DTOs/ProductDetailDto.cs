using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsApi.Application.DTOs
{
    public record ProductDetailDto
    (
        int Id,
        string Title,
        string? Description,
        decimal Price,
        string Category,
        string? ThumbnailUrl,
        IEnumerable<string> ImageUrls
    );
}
