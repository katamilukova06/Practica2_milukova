namespace ShopAccessories.Application.Requests;

public class OrderRequests
{
    public int ProductId { get; set; }
    public int ClientId { get; set; }
    public int SellerId { get; set; }
    public int DatePurchase { get; set; }
}