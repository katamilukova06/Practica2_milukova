using ShopAccessories.Models;

namespace ShopAccessories.Application.Responses;

public class SellerResponse
{
    public int SellerId { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public Order Order { get; set; }
}