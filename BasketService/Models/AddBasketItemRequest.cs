namespace BasketService.Models;

public class AddBasketItemRequest
{
    public string ProductCode { get; set; }
    public int Quantity { get; set; }
}