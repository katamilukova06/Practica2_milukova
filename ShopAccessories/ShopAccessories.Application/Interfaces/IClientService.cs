using ShopAccessories.Application.Requests;
using ShopAccessories.Application.Responses;

namespace ShopAccessories.Application.Interfaces;

public interface IClientService
{
    Task<ClientResponse> CreateClientAsync(CreateClientRequests request);
    Task<ClientResponse> GetClientByIdAsync(ClientRequests request);
    Task<IEnumerable<ClientResponse>> GetAllClientAsync();
    Task<ClientResponse> UpdateClientAsync(UpdateClientRequests request);
    Task DeleteClientAsync(ClientRequests request);

}