using System.ComponentModel.DataAnnotations;
using MeLi_Clone_users_ms.Domain.Models;

namespace MeLi_Clone_users_ms.Domain.DTOs;

public class SimpleUserDto
{
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string LastName { get; set; }
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string ImageUrl { get; set; }
}