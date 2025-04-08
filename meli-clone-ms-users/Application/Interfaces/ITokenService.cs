using MeLi_Clone_users_ms.Domain.Models;

namespace MeLi_Clone_users_ms.Application.Interfaces;

public interface ITokenService
{
    public string GenerateToken(User user);
    public void ValidateToken(string? token);
    //public void ValidateCartToken(string token);
    public int GetUserIdFromToken(string token);
}