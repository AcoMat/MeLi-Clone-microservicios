using meli_clone_ms_products.Application.DTOs;
using meli_clone_ms_products.Domain.Entities;
using meli_clone_ms_products.Domain.Interfaces.Repositories;

namespace meli_clone_ms_products.Application.UseCases;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Product?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return await _repository.GetByIdAsync(id, cancellationToken);
    }
    
}