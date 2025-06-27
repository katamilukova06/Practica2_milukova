using System.Configuration;
using AutoMapper;
using ShopAccessories.Application.Interfaces;
using ShopAccessories.Application.Requests;
using ShopAccessories.Application.Responses;
using ShopAccessories.Models;
using ShopAccessories.Repository;

namespace ShopAccessories.Application.Services;

public class ClientService : IClientService
{
    private readonly IRepository<Client> _clientRepository;
    private readonly IMapper _mapper;

    public ClientService(IRepository<Client> clientRepository, IMapper mapper)
    {
        _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<ClientResponse> CreateClientAsync(CreateClientRequests request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        var client = _mapper.Map<Client>(request);
        await _clientRepository.AddAsync(client);
        return _mapper.Map<ClientResponse>(client);
    }

    public async Task<ClientResponse> GetClientByIdAsync(ClientRequests request)
    {
        var client = await _clientRepository.GetByKeysAsync(request.ClientId);
        if (client == null) throw new KeyNotFoundException($"Client with ID {request.ClientId} not found.");
        return _mapper.Map<ClientResponse>(client);
    }

    public async Task<IEnumerable<ClientResponse>> GetAllClientAsync()
    {
        var client =_clientRepository.GetAllAsync().Result; // Assuming cached or in-memory
        return _mapper.Map<IEnumerable<ClientResponse>>(client);
    }

    public async Task<ClientResponse> UpdateClientAsync(UpdateClientRequests request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        var client = await _clientRepository.GetByKeysAsync(request.ClientId);
        if (client == null) throw new KeyNotFoundException($"Client with ID {request.ClientId} not found.");
        
        _mapper.Map(request, client);
        _clientRepository.Update (client);
        await _clientRepository.SaveChangesAsync();
        return _mapper.Map<ClientResponse>(client);
    }
    

    public async Task DeleteClientAsync(ClientRequests request)
    {
        var client = await _clientRepository.GetByKeysAsync(request.ClientId);
        if (client == null) throw new KeyNotFoundException($"Client with ID {request.ClientId} not found.");
        await _clientRepository.Delete(client);
        
    }
}