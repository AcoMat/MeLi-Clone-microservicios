using System.ComponentModel.DataAnnotations;
using MeLi_Clone_users_ms.Domain.Models;

namespace MeLi_Clone_users_ms.Domain.DTOs;

public record PurchaseDto
{
    [Required]
    public int UserId { get; set; }
    [Required]
    public List<int> ProductsIds { get; set; }
    [Required]
    public DateTime PurchaseDate { get; set; }
    [Required]
    public decimal PurchasePrice { get; set; }
}