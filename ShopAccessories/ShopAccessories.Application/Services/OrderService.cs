using AutoMapper;
using ShopAccessories.Application.Interfaces;
using ShopAccessories.Application.Requests;
using ShopAccessories.Application.Responses;
using ShopAccessories.Models;
using ShopAccessories.Repository;

namespace ShopAccessories.Application.Services;

public class OrderService : IOrderService
{
    private readonly IRepository<Client> _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IRepository<Client> orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<OrderResponse> CreateOrderAsync(CreateOrderRequests request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        var order = _mapper.Map<Order>(request);
        return _mapper.Map<OrderResponse>(order);
    }

    public async Task<OrderResponse> GetOrderByIdAsync(OrderRequests request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        var order = _mapper.Map<Order>(request);
        if (order == null) throw new KeyNotFoundException($"Order with ID {request.ProductId} not found");
        return _mapper.Map<OrderResponse>(order);
    }

    public async Task<IEnumerable<OrderResponse>> GetAllOrderAsync()
    {
        var order =_orderRepository.GetAllAsync().Result; // Assuming cached or in-memory
        return _mapper.Map<IEnumerable<OrderResponse>>(order);
    }

    public async Task<OrderResponse> UpdateOrderAsync(UpdateOrderRequests request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        var order = await _orderRepository.GetByKeysAsync(request.ProductId);
        if (order == null) throw new KeyNotFoundException($"Order with ID {request.ProductId} not found.");
        
        _mapper.Map(request, order);
        _orderRepository.Update (order);
        await _orderRepository.SaveChangesAsync();
        return _mapper.Map<OrderResponse>(order);
    }


    public async Task DeleteOrderAsync(OrderRequests request)
    {
        var order = await _orderRepository.GetByKeysAsync(request.ProductId);
        if (order == null) throw new KeyNotFoundException($"Order with ID {request.ProductId} not found.");
        await _orderRepository.Delete(order);
        
    }
}