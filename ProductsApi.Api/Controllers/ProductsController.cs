
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Application.Stories.Products;

namespace ProductsApi.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
        
    public class ProductsController(GetProducts getAll,GetProductById getById,SearchProducts search): ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
             return Ok(await getAll.ExecuteAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest(new { message = "Invalid product Id" });
            var product = await getById.ExecuteAsync(id);
            if(product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest(new { message = "Search query cannot be empty" });
            }
            if (query.Length > 100)
            {
                return BadRequest(new { message = "Search query exceeded maximum characters" });
            }

            return Ok(await search.ExecuteAsync(query));

        }
        
    }
}
