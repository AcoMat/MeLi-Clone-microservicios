using System.ComponentModel.DataAnnotations;

namespace MeLi_Clone_users_ms.Domain.Models;

public class Purchase
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public List<int> ProductsIds { get; set; }
    [Required]
    public DateTime PurchaseDate { get; set; }
    [Required]
    public decimal PurchasePrice { get; set; }
    [Required]
    public User User { get; set; }
}