using AutoMapper;
using ShopAccessories.Application.Interfaces;
using ShopAccessories.Application.Requests;
using ShopAccessories.Application.Responses;
using ShopAccessories.Models;
using ShopAccessories.Repository;

namespace ShopAccessories.Application.Services;

public class OrderCompositionService : IOrderCompositionService
{
    private readonly IRepository<OrderComposition> _orderCompositionRepository;
    private readonly IMapper _mapper;

    public OrderCompositionService(IRepository<OrderComposition> orderCompositionRepository, IMapper mapper)
    {
        _orderCompositionRepository = orderCompositionRepository ?? throw new ArgumentNullException(nameof(orderCompositionRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<OrderCompositionsResponse> CreateOrderCompositionAsync(CreateOrderCompositionRequests request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        var orderComposition = _mapper.Map<Client>(request);
        return _mapper.Map<OrderCompositionsResponse>(orderComposition);
    }

    public async Task<OrderCompositionsResponse> GetOrderCompositionByIdAsync(OrderCompositionRequests request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        var orderComposition = _mapper.Map<Order>(request);
        if (orderComposition == null) throw new KeyNotFoundException($"OrderComposition with ID {request.ProductId} not found");
        return _mapper.Map<OrderCompositionsResponse>(orderComposition);
    }

    public Task<IEnumerable<OrderCompositionsResponse>> GetOrderCompositionByProductIdAsync(OrderCompositionRequests productRequest)
    {
        throw new NotImplementedException();
    }

    public Task<OrderCompositionsResponse> UpdateCommentAsync(UpdateOrderCompositionRequests request)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<OrderCompositionsResponse>> GetAllOrderCompositionAsync()
    {
        var orderComposition =_orderCompositionRepository.GetAllAsync().Result; // Assuming cached or in-memory
        return _mapper.Map<IEnumerable<OrderCompositionsResponse>>(orderComposition); 
    }

    public async Task<OrderCompositionsResponse> UpdateOrderCompositionAsync(UpdateOrderCompositionRequests request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        var orderComposition = await _orderCompositionRepository.GetByKeysAsync(request.ProductId);
        if (orderComposition == null) throw new KeyNotFoundException($"OrderComposition with ID {request.ProductId} not found.");
        
        _mapper.Map(request, orderComposition);
        _orderCompositionRepository.Update (orderComposition);
        await _orderCompositionRepository.SaveChangesAsync();
        return _mapper.Map<OrderCompositionsResponse>(orderComposition);
    }


    public async Task DeleteOrderCompositionAsync(OrderCompositionRequests request)
    {
        var order = await _orderCompositionRepository.GetByKeysAsync(request.ProductId);
        if (order == null) throw new KeyNotFoundException($"OrderComposition with ID {request.ProductId} not found.");
        await _orderCompositionRepository.Delete(order);
        
    }
}