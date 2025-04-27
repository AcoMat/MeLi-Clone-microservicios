using meli_clone_ms_products.Application.DTOs;
using meli_clone_ms_products.Application.Mappers;
using meli_clone_ms_products.Domain.Interfaces.Repositories;
using meli_clone_ms_products.Infrastructure.External;

namespace meli_clone_ms_products.Application.UseCases;

public class ProductService
{
    private readonly IProductRepository _repository;
    private readonly MeLiApiService _external;
    private readonly ILogger<ProductService> _logger;

    public ProductService(IProductRepository repository, MeLiApiService external, ILogger<ProductService> logger)
    {
        _repository = repository;
        _external = external;
        _logger = logger;
    }
    
    public async Task<ProductDto?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var product = await _repository.GetByIdAsync(id, cancellationToken);
        if(product is not null)
        {
            // Product found in database, convert to DTO and return
            _logger.LogInformation("Product with ID {Id} found in database", id);
            return product.ToDTO();
        }
        
        // Product not found in database, try to fetch from external API
        _logger.LogInformation("Product with ID {Id} not found in database, fetching from external API", id);
        var externalProduct = await _external.GetProductByIdAsync(id, cancellationToken);
        if(externalProduct is null)
        {
            _logger.LogWarning("Product with ID {Id} not found in external API", id);
            return null;
        }
        
        // Map external product to domain entity
        var newProduct = externalProduct.ToEntity();
        
        return newProduct.ToDTO();
    }
    
    public async Task<List<ProductDto>?> SearchAsync(string query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
