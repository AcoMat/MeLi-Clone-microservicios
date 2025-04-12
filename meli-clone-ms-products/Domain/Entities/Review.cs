using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using meli_clone_ms_products.Domain.Entities;

namespace meli_clone_ms_products.Domain.Entities;

public class Review
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string UserId { get; set; }
    public Product Product { get; set; }
    [Required]
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
    public int Rating { get; set; }
    [Required]
    [MaxLength(500)]
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}