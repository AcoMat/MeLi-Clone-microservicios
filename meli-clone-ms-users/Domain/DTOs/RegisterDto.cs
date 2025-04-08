using System.ComponentModel.DataAnnotations;

namespace MeLi_Clone_users_ms.Domain.DTOs
{
    public record RegisterDto
    {
        [Required]
        public required string Name { get; set; }
        public required string LastName { get; set; }
        [Required, EmailAddress]
        public required string Email { get; set; }
        [Required, MinLength(6)]
        public required string Password { get; set; }
        [Required, Compare(nameof(Password))]
        public required string ConfirmPassword { get; set; }
        public required string ImageURL { get; set; }
    }
}
