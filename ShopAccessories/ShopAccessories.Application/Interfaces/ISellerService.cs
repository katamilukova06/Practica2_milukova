using ShopAccessories.Application.Requests;
using ShopAccessories.Application.Responses;

namespace ShopAccessories.Application.Interfaces;

public interface ISellerService
{
    Task<SellerResponse> CreateSellerAsync(CreateSellerRequests request);
    Task<SellerResponse> GetSellerByIdAsync(SellerRequests request);
    Task<IEnumerable<SellerResponse>> GetAllSellerAsync();
    Task<SellerResponse> UpdateSellerAsync(UpdateSellerRequests request);
    Task DeleteSellerAsync(SellerRequests request);

}