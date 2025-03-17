using System.ComponentModel.DataAnnotations;

namespace MeLi_Clone_users_ms.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string ImageURL { get; set; }

    }
}
  