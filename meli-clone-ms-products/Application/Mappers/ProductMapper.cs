using meli_clone_ms_products.Application.DTOs;
using meli_clone_ms_products.Domain.Entities;
using meli_clone_ms_products.Infrastructure.External.Dtos;
using System.Collections.Generic;
using System.Linq;
using Attribute = meli_clone_ms_products.Domain.Entities.Attribute;

namespace meli_clone_ms_products.Application.Mappers;

public static class ProductMapper
{
    public static ProductDto ToDTO(this Product product)
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
    
    public static Product ToEntity(this MeLiApiProductDto externalProduct)
    {
        // Create a basic category from the CategoryId
        var category = new Category 
        { 
            Id = externalProduct.CategoryId,
            Name = externalProduct.CategoryId // Using CategoryId as Name temporarily
        };
        
        // Map attributes from external format to domain format
        var attributes = externalProduct.Attributes?.Select(a => new Attribute
        {
            Name = a.Name,
            Value = a.ValueName ?? a.Values?.FirstOrDefault()?.Name ?? string.Empty
        }).ToList() ?? new List<Attribute>();
        
        return new Product
        {
            Id = externalProduct.Id,
            Category = category,
            Name = externalProduct.Name,
            Pictures = externalProduct.PictureUrls,
            SellerId = externalProduct.SellerId.ToString(),
            Price = externalProduct.Price,
            Attributes = attributes,
            MinStock = 0, // Default value
            Description = externalProduct.Description,
            // Questions and Reviews will be empty collections by default
        };
    }
}
