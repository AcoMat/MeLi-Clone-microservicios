using meli_clone_ms_products.Application.Interfaces;
using meli_clone_ms_products.Application.UseCases;
using meli_clone_ms_products.Domain.Interfaces.Repositories;
using meli_clone_ms_products.Infrastructure.Data;
using meli_clone_ms_products.Infrastructure.External;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProductDbContext>(options => options.UseSqlServer(connectionString));

// Inyección de dependencias
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/products/{id}", async (string id, ProductService service) =>
{
    var product = await service.GetByIdAsync(id);
    return product is null ? Results.NotFound() : Results.Ok(product);
});

app.Run();

