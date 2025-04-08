using System.ComponentModel.DataAnnotations;

namespace MeLi_Clone_users_ms.Domain.DTOs;

public record LikeDto
{
    [Required]
    public int ProductId { get; set; }
}