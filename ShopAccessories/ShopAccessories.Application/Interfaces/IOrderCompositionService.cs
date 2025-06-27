using ShopAccessories.Application.Requests;
using ShopAccessories.Application.Responses;
using ShopAccessories.Models;

namespace ShopAccessories.Application.Interfaces;

public interface IOrderCompositionService
{
    Task<OrderCompositionsResponse> CreateOrderCompositionAsync(CreateOrderCompositionRequests request);
    Task<OrderCompositionsResponse> GetOrderCompositionByIdAsync(OrderCompositionRequests request);
    Task<IEnumerable<OrderCompositionsResponse>> GetOrderCompositionByProductIdAsync(OrderCompositionRequests productRequest);
    Task<OrderCompositionsResponse> UpdateCommentAsync(UpdateOrderCompositionRequests request);
    Task DeleteOrderCompositionAsync(OrderCompositionRequests request);

}