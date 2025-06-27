namespace ShopAccessories.Application.Requests;

public class CreateOrderRequests
{
    public int ProductId { get; set; }
    public int ClientId { get; set; }
    public int SellerId { get; set; }
}