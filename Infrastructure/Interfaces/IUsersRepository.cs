using MeLi_Clone_users_ms.Domain.Models;

namespace MeLi_Clone_users_ms.Infrastructure.Interfaces
{
    public interface IUsersRepository
    {
        Task<User?> GetUserById(int id);
        Task<User?> GetUserByEmail(string email);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);

    }
}
