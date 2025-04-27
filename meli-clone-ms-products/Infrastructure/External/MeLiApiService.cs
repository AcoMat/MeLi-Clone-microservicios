using meli_clone_ms_products.Domain.Entities;
using meli_clone_ms_products.Infrastructure.External.Dtos;

namespace meli_clone_ms_products.Infrastructure.External;

public class MeLiApiService
{
    
    private readonly HttpClient _httpClient;
    private readonly ILogger<MeLiApiProductDto> _logger;

    public MeLiApiService(HttpClient httpClient, ILogger<MeLiApiProductDto> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
    
    public async Task<MeLiApiProductDto?> GetProductByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/products/{id}";
        try
        {
            var meLiApiProduct = await _httpClient.GetFromJsonAsync<MeLiApiProductDto>(endpoint, cancellationToken);
            return meLiApiProduct;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Error HTTP al llamar a {Endpoint}. StatusCode: {StatusCode}", endpoint, ex.StatusCode);
            return null;
        }
        catch (Exception ex) // Captura otras excepciones (ej. JsonException, TaskCanceledException)
        {
            _logger.LogError(ex, "Error inesperado al llamar a {Endpoint}", endpoint);
            return null;
        }
    }
}