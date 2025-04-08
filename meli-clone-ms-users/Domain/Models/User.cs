using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MeLi_Clone_users_ms.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(20)]
        public required string Name { get; set; }

        [Required, MaxLength(20)]
        public required string LastName { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required] 
        public required string PasswordHash { get; set; }

        [Required]
        public required string ImageURL { get; set; }

        public List<int> FavoriteProducts { get; set; } = [];
        public List<Purchase> PurchaseHistory { get; set; } = [];
    }
}
  