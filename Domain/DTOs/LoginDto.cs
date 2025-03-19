using System.ComponentModel.DataAnnotations;

namespace MeLi_Clone_users_ms.Domain.DTOs
{
    public record LoginDto
    {
        [Required(ErrorMessage = "El correo electrónico es obligatorio"), EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Falta ingresar la contraseña"), MinLength(6)]
        public string Password { get; set; }
    }
}
