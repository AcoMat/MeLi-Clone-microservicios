using meli_clone_ms_products.Application.DTOs;
using meli_clone_ms_products.Domain.Entities;

namespace meli_clone_ms_products.Application.Mappers;

public static class ReviewMapper
{
    public static ReviewDto ToDTO(Review review)
    {
        if (review == null) return null;

        return new ReviewDto
        (
            review.UserId,
            review.Comment,
            review.Rating,
            review.CreatedAt
        );
    }
}

// Extension methods for easier mapping
public static class ReviewMapperExtensions
{
    public static ReviewDto ToDTO(this Review review)
    {
        return ReviewMapper.ToDTO(review);
    }
}
