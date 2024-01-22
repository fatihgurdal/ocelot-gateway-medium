using BasketService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasketService.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BasketController : ControllerBase
{
    // GET
    [HttpPost(Name = "add-basket-item")]
    public ActionResult AddBasketItem([FromBody] AddBasketItemRequest request)
    {
        return Accepted(new
        {
            Message=$"{request.ProductCode} product {request.Quantity} added to basket"
        });
    }
}