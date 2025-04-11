namespace meli_clone_ms_products.Application.DTOs;

public record ProductDto(
    string Id,
    string CategoryId,
    CategoryDto? Category,
    string Name,
    List<string> Pictures,
    string SellerName,
    string SellerId,
    decimal Price,
    Dictionary<string, string> Attributes,
    int Stock,
    string Description,
    List<QuestionDto>? Questions,
    List<ReviewDto>? Reviews
);

// DTOs for related entities
public record CategoryDto(
    string Id,
    string Name
);

public record QuestionDto(
    string Id,
    string Question,
    string Answer,
    string UserId,
    DateTime CreatedAt,
    DateTime? AnsweredAt
);

public record ReviewDto(
    string Id,
    string UserId,
    string Comment,
    int Rating,
    DateTime CreatedAt
);
