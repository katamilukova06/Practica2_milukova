using ShopAccessories.Application.Requests;
using ShopAccessories.Application.Responses;

namespace ShopAccessories.Application.Interfaces;

public interface IOrderService
{
    Task<OrderResponse> CreateOrderAsync(CreateOrderRequests request);
    Task<OrderResponse> GetOrderByIdAsync(OrderRequests request);
    Task<IEnumerable<OrderResponse>> GetAllOrderAsync();
    Task<OrderResponse> UpdateOrderAsync(UpdateOrderRequests request);
    Task DeleteOrderAsync(OrderRequests request);

}