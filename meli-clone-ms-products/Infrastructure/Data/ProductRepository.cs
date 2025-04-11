using meli_clone_ms_products.Domain.Entities;
using meli_clone_ms_products.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace meli_clone_ms_products.Infrastructure.Data;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _context;
    
    public ProductRepository(ProductDbContext context)
    {
        _context = context;
    }
    
    public async Task<Product?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return await _context.Products.FindAsync([id], cancellationToken);
    }

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Products.ToListAsync(cancellationToken);
    }

    public async Task CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Products.FindAsync([id], cancellationToken);
        if (entity is not null)
        {
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}