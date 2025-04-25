using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace meli_clone_ms_products.Domain.Entities;
public class Product
{
    [StringLength(50, MinimumLength = 1)]
    [Key]
    public string Id { get; set; }
    
    public required Category Category { get; set; }
    
    [StringLength(100, MinimumLength = 1)]
    public required string Name { get; set; }
    
    [MinLength(1, ErrorMessage = "At least one picture is required.")]
    public required List<string> Pictures { get; set; }
    
    
    public required String SellerId { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
    public required decimal Price { get; set; }
    
    public int discount { get; set; } = 0;

    public ICollection<Attribute> Attributes { get; set; } = [];

    [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative.")] 
    public int MinStock { get; set; }

    [StringLength(1000, MinimumLength = 1)] 
    public required string Description { get; set; }

    public List<Question> Questions { get; set; } = [];

    public List<Review> Reviews { get; set; } = [];
    
}
