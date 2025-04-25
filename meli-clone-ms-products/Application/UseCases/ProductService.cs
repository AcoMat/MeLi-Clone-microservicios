using meli_clone_ms_products.Application.DTOs;
using meli_clone_ms_products.Application.Mappers;
using meli_clone_ms_products.Domain.Interfaces.Repositories;

namespace meli_clone_ms_products.Application.UseCases;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<ProductDto?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var product = await _repository.GetByIdAsync(id, cancellationToken);
        return product == null ? null : ProductMapper.ToDTO(product);
    }
    
}