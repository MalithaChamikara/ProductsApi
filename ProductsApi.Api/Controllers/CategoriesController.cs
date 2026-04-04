using Microsoft.AspNetCore.Mvc;
using ProductsApi.Application.Stories.Categories;

namespace ProductsApi.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController(GetCategories getAll,GetProductsByCategory getByCategory): ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult>  GetAll()
        {
            return Ok(await getAll.ExecuteAsync());
        }

        [HttpGet("{slug:string}/products")]
        public  async Task<IActionResult> GetByCategory(string slug)
        {
            if(string.IsNullOrWhiteSpace(slug))
            {
                return BadRequest(new { message = "Category slug is required" });
            }

            return Ok(await getByCategory.ExecuteAsync(slug));
        }
    }
}
