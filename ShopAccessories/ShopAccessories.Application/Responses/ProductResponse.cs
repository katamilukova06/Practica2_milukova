using ShopAccessories.Models;

namespace ShopAccessories.Application.Responses;

public class ProductResponse
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int Price { get; set; }
    public OrderComposition OrderComposition { get; set; }
}