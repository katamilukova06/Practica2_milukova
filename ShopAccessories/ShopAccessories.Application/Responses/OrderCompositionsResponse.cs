using ShopAccessories.Models;

namespace ShopAccessories.Application.Responses;

public class OrderCompositionsResponse
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public List<OrderComposition> OrderCompositions { get; set; }
}