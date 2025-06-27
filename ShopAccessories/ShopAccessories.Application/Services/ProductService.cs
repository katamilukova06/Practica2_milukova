using AutoMapper;
using ShopAccessories.Application.Interfaces;
using ShopAccessories.Application.Requests;
using ShopAccessories.Application.Responses;
using ShopAccessories.Models;
using ShopAccessories.Repository;

namespace ShopAccessories.Application.Services;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IRepository<Product> productRepository, IMapper mapper)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<ProductResponse> CreateProductAsync(CreateProductRequests request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        var product = _mapper.Map<Product>(request);
        return _mapper.Map<ProductResponse>(product);
    }

    public async Task<ProductResponse> GetProductByIdAsync(ProductRequests request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        var product = _mapper.Map<Product>(request);
        if (product == null) throw new KeyNotFoundException($"Product with ID {request.ProductId} not found");
        return _mapper.Map<ProductResponse>(product);
    }

    public async Task<IEnumerable<ProductResponse>> GetAllProductAsync()
    {
        var product =_productRepository.GetAllAsync().Result; // Assuming cached or in-memory
        return _mapper.Map<IEnumerable<ProductResponse>>(product);
    }

    public async Task<ProductResponse> UpdateProductAsync(UpdateProductRequests request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        var product = await _productRepository.GetByKeysAsync(request.ProductId);
        if (product == null) throw new KeyNotFoundException($"Product with ID {request.ProductId} not found.");
        
        _mapper.Map(request, product);
        _productRepository.Update (product);
        await _productRepository.SaveChangesAsync();
        return _mapper.Map<ProductResponse>(product);
    }
    
    public async Task DeleteProductAsync(ProductRequests request)
    {
        var product = await _productRepository.GetByKeysAsync(request.ProductId);
        if (product == null) throw new KeyNotFoundException($"Product with ID {request.ProductId} not found.");
        await _productRepository.Delete(product);
        
    }
}