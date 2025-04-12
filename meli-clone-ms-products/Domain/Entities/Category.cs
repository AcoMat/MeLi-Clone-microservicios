using System.ComponentModel.DataAnnotations;

namespace meli_clone_ms_products.Domain.Entities;

public class Category
{
    [Required]
    public string Id { get; set; }
    [Required]
    public string Name { get; set; }
}