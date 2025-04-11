using System.ComponentModel.DataAnnotations;

namespace meli_clone_ms_products.Domain.Entities;
public class Product
{
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string Id { get; private set; }

    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string CategoryId { get; private set; }

    [Required]
    public virtual Category Category { get; private set; }

    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Name { get; private set; }

    [Required]
    [MinLength(1, ErrorMessage = "At least one picture is required.")]
    public List<string> Pictures { get; private set; }

    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string SellerName { get; private set; }

    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string SellerId { get; private set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
    public decimal Price { get; private set; }

    public Dictionary<string, string> Attributes { get; private set; }

    [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative.")]
    public int Stock { get; private set; }

    [Required]
    [StringLength(1000, MinimumLength = 1)]
    public string Description { get; private set; }

    [Required]
    public virtual List<Question> Questions { get; private set; }

    [Required]
    public virtual List<Review> Reviews { get; private set; }

    private Product()
    {
        Attributes = new Dictionary<string, string>();
        Questions = new List<Question>();
        Reviews = new List<Review>();
    }
}
