using System.ComponentModel.DataAnnotations;
using MeLi_Clone_users_ms.Domain.Models;

namespace MeLi_Clone_users_ms.Domain.DTOs;

public class SimpleUserDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string ImageURL { get; set; }
}