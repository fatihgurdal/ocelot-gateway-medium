using BasketService.Hubs;
using BasketService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BasketService.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BasketController : ControllerBase
{
    private readonly IHubContext<BaskerHub> _hubContext;

    public BasketController(IHubContext<BaskerHub> hubContext)
    {
        _hubContext = hubContext;
    }

    // GET
    [HttpPost(Name = "add-basket-item")]
    public async Task<ActionResult> AddBasketItem([FromBody] AddBasketItemRequest request)
    {
        await _hubContext.Clients.All.SendAsync("basketUpdated", request);
        return Accepted(new
        {
            Message = $"{request.ProductCode} product {request.Quantity} added to basket"
        });
    }
}