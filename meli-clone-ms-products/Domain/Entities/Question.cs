using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace meli_clone_ms_products.Domain.Entities;

public class Question
{
    [Key]
    public string Id { get; set; }
    [Required]
    public string UserId { get; set; }
    [Required]
    public Product Product { get; set; }
    [Required]
    [MaxLength(500)]
    public string QuestionText { get; set; }
    [MaxLength(1000)]
    public string? responseText { get; set; }
}
