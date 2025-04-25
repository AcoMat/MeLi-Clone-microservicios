namespace meli_clone_ms_products.Application.DTOs;

public record ProductDto(
    string Id,
    CategoryDto Category,
    string Name,
    List<string> Pictures,
    string SellerName,
    decimal Price,
    Dictionary<string, string> Attributes,
    int Stock,
    string Description,
    List<QuestionDto>? Questions,
    List<ReviewDto>? Reviews
);

// DTOs for related entities
public record CategoryDto(
    string Name
);

public record QuestionDto(
    string UserId,
    string Question,
    string? Answer,
    DateTime CreatedAt,
    DateTime? AnsweredAt
);

public record ReviewDto(
    string UserName,
    string Comment,
    int Rating,
    DateTime CreatedAt
);
