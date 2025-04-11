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

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        /*
        var products = await _repository.GetAllAsync();
        return products.Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock));
        */
        throw new NotImplementedException();
    }

    public async Task<ProductDto?> GetByIdAsync(string id)
    {
        /*
        var p = await _repository.GetByIdAsync(id);
        return p is null ? null : new ProductDto(p.Id, p.Name, p.Price, p.Stock);
    */
    throw new NotImplementedException();
    }
    

    public async Task DeleteAsync(string id) => await _repository.DeleteAsync(id);
}