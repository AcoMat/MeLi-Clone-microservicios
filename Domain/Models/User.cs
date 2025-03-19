using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MeLi_Clone_users_ms.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(20)]
        public string Name { get; set; }

        [Required, MaxLength(20)]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required] 
        public string PasswordHash { get; set; }

        [Required]
        public string ImageURL { get; set; }

        public List<int> FavoriteProducts { get; set; } = [];
        public List<Purchase> PurchaseHistory { get; set; } = [];
    }
}
  