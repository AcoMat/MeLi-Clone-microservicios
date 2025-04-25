using meli_clone_ms_products.Application.DTOs;
using meli_clone_ms_products.Domain.Entities;

namespace meli_clone_ms_products.Application.Mappers;

public static class CategoryMapper
{
    public static CategoryDto ToDTO(Category category)
    {
        if (category == null) return null;

        return new CategoryDto
        (
            category.Name
        );
    }
}

// Extension methods for easier mapping
public static class CategoryMapperExtensions
{

    public static CategoryDto ToDTO(this Category category)
    {
        return CategoryMapper.ToDTO(category);
    }
}
