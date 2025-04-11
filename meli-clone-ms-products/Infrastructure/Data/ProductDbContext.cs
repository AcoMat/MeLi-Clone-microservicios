using meli_clone_ms_products.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace meli_clone_ms_products.Infrastructure.Data;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();
}