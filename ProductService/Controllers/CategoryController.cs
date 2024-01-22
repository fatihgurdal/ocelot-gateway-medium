using Microsoft.AspNetCore.Mvc;
using ProductService.Models;

namespace ProductService.Controllers;

[Route("api/[controller]/[action]")]
public class CategoryController : ControllerBase
{
    [HttpGet(Name = "get-categories")]
    public ActionResult<IEnumerable<CategoryResponse>> GetCategories()
    {
        var response = Enumerable.Range(1, 5).Select(x => new CategoryResponse()
        {
            Id = x,
            Name = $"Menu {x}",
            Route = $"menu-{x}"
        });
        return Ok(response);
    }
}