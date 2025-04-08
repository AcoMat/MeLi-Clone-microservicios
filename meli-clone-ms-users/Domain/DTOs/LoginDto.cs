using System.ComponentModel.DataAnnotations;

namespace MeLi_Clone_users_ms.Domain.DTOs
{
    public record LoginDto
    {
        [Required(ErrorMessage = "El correo electrónico es obligatorio"), EmailAddress]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Falta ingresar la contraseña"), MinLength(6)]
        public required string Password { get; set; }
    }
}
