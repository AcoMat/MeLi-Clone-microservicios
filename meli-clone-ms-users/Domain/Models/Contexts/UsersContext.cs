using Microsoft.EntityFrameworkCore;

namespace MeLi_Clone_users_ms.Domain.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

    }
}
