namespace ShopAccessories.Application.Requests;

public class UpdateProductRequests
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int Price { get; set; }
    public int ProductId { get; set; }
}