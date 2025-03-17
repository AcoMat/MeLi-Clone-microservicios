using MeLi_Clone_users_ms.Domain.DTOs;
using MeLi_Clone_users_ms.Domain.Models;

namespace MeLi_Clone_users_ms.Application.Interfaces
{
    public interface IAuthService
    {
        Task<User> RegisterUser(RegisterDTO registerDTO);
        Task<User> Login(LoginDTO loginDTO);
    }
}
