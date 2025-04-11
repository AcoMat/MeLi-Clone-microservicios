using meli_clone_ms_products.Domain.Entities;

namespace meli_clone_ms_products.Domain.Entities;

public class Review
{
    int Id { get; set; }
    string UserId { get; set; }
    string ProductId { get; set; }
    public virtual Product Product { get; set; }
    int Rating { get; set; }
    string Comment { get; set; }
    DateTime CreatedAt { get; set; }
}