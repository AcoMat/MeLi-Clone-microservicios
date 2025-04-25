using meli_clone_ms_products.Application.DTOs;
using meli_clone_ms_products.Domain.Entities;
using Attribute = meli_clone_ms_products.Domain.Entities.Attribute;

namespace meli_clone_ms_products.Application.Mappers;

public static class ProductMapper
{

    public static ProductDto ToDTO(Product product)
    {
        return new ProductDto
        (
            product.Id,
            product.Category.ToDTO(),
            product.Name,
            product.Pictures,
            product.SellerId,
            product.Price,
            product.Attributes.ToDictionary(a => a.Name, a => a.Value),
            product.MinStock,
            product.Description,
            product.Questions.Select(q => q.ToDTO()).ToList(),
            product.Reviews.Select(r => r.ToDTO()).ToList()
        );
    }
}
