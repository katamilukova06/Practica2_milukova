using ShopAccessories.Application.Requests;
using ShopAccessories.Application.Responses;

namespace ShopAccessories.Application.Interfaces;

public interface IProductService
{
    Task<ProductResponse> CreateProductAsync(CreateProductRequests request);
    Task<ProductResponse> GetProductByIdAsync(ProductRequests request);
    Task<IEnumerable<ProductResponse>> GetAllProductAsync();
    Task<ProductResponse> UpdateProductAsync(UpdateProductRequests request);
    Task DeleteProductAsync(ProductRequests request);

}