using ShopAccessories.Models;

namespace ShopAccessories.Application.Responses;

public class ClientResponse
{
    public int ClientId { get; set; }
    public string Name { get; set; }
    public Order Order { get; set; }
}