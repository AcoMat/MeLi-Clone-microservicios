using MeLi_Clone_users_ms.Domain.DTOs;
using MeLi_Clone_users_ms.Domain.Models;

namespace MeLi_Clone_users_ms.Application.Interfaces
{
    public interface IUsersService
    {
        Task<User> RegisterUser(RegisterDto registerDTO);
        Task<User> Login(LoginDto loginDTO);
        Task<User> GetUser(int id);
        Task<User> AddLikedProduct(int userId, int productId);
        Task<User> AddPurchase(PurchaseDto purchaseDto);
        
    }
}
