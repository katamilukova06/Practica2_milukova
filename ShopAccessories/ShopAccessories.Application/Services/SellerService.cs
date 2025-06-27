using AutoMapper;
using ShopAccessories.Application.Interfaces;
using ShopAccessories.Application.Requests;
using ShopAccessories.Application.Responses;
using ShopAccessories.Models;
using ShopAccessories.Repository;

namespace ShopAccessories.Application.Services;

public class SellerService : ISellerService
{
     private readonly IRepository<Seller> _sellerRepository;
    private readonly IMapper _mapper;

    public SellerService(IRepository<Seller> sellerRepository, IMapper mapper)
    {
        _sellerRepository = sellerRepository ?? throw new ArgumentNullException(nameof(sellerRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<SellerResponse> CreateSellerAsync(CreateSellerRequests request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        var seller = _mapper.Map<Seller>(request);
        return _mapper.Map<SellerResponse>(seller);
    }

    public async Task<SellerResponse> GetSellerByIdAsync(SellerRequests request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        var seller = _mapper.Map<Seller>(request);
        if (seller == null) throw new KeyNotFoundException($"Seller with ID {request.SellerId} not found");
        return _mapper.Map<SellerResponse>(seller);
    }

    public async Task<IEnumerable<SellerResponse>> GetAllSellerAsync()
    {
        var seller =_sellerRepository.GetAllAsync().Result; // Assuming cached or in-memory
        return _mapper.Map<IEnumerable<SellerResponse>>(seller);
    }

    public async Task<SellerResponse> UpdateSellerAsync(UpdateSellerRequests request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        var seller = await _sellerRepository.GetByKeysAsync(request.SellerId);
        if (seller == null) throw new KeyNotFoundException($"Seller with ID {request.SellerId} not found.");
        
        _mapper.Map(request, seller);
        _sellerRepository.Update (seller);
        await _sellerRepository.SaveChangesAsync();
        return _mapper.Map<SellerResponse>(seller);
    }
    
    public async Task DeleteSellerAsync(SellerRequests request)
    {
        var seller = await _sellerRepository.GetByKeysAsync(request.SellerId);
        if (seller == null) throw new KeyNotFoundException($"Seller with ID {request.SellerId} not found.");
        await _sellerRepository.Delete(seller);
        
    }
}