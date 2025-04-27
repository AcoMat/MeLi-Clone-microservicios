using meli_clone_ms_products.Application.UseCases;
using meli_clone_ms_products.Domain.Interfaces.Repositories;
using meli_clone_ms_products.Infrastructure.Data;
using meli_clone_ms_products.Infrastructure.External;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProductDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddHttpClient<MeLiApiService>(client =>
{
    string? baseUrl = builder.Configuration.GetValue<string>("ApiSettings:BaseUrl");
    if (string.IsNullOrWhiteSpace(baseUrl))
    {
        throw new InvalidOperationException(
            "La URL base de la API ('ApiSettings:BaseUrl') no está configurada en appsettings.json");
    }

    client.BaseAddress = new Uri(baseUrl);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.Timeout = TimeSpan.FromSeconds(30);
    
    string? token = builder.Configuration.GetValue<string>("ApiSettings:Token");
    if (string.IsNullOrWhiteSpace(token))
    {
        throw new InvalidOperationException(
            "El token de autorización ('ApiSettings:Token') no está configurado en appsettings.json");
    }

    client.DefaultRequestHeaders.Add("Authorization", token);
});

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

app.MapGet("/search/{query}", async (string query, ProductService service) =>
{
    var products = await service.SearchAsync(query);
    return products is null ? Results.NotFound() : Results.Ok(products);
});

app.Run();

