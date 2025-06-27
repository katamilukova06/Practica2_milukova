using ShopAccessories.Models;

namespace ShopAccessories.Application.Responses;

public class OrderResponse
{
    public int ProductId { get; set; }
    public int ClientId { get; set; }
    public int SellerId { get; set; }
    public int DatePurchase { get; set; }
    public OrderComposition OrderComposition { get; set; }
    public List<Client> Orders { get; set; }
}