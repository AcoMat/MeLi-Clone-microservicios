using System.ComponentModel.DataAnnotations;
using MeLi_Clone_users_ms.Domain.Models;

namespace MeLi_Clone_users_ms.Domain.DTOs
{
    public record UserDto
    {
        public UserDto(User user)
        {
            Name = user.Name;
            LastName = user.LastName;
            Email = user.Email;
            ImageURL = user.ImageURL;
            FavoriteProducts = user.FavoriteProducts;
            PurchaseHistory = user.PurchaseHistory;
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string ImageURL { get; set; }
        public List<int> FavoriteProducts { get; set; }
        public List<Purchase> PurchaseHistory { get; set; }
    }

}
