using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using MeLi_Clone_users_ms.Application.Interfaces;
using MeLi_Clone_users_ms.Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace MeLi_Clone_users_ms.Application.Services;

public class TokenService : ITokenService
{
    private const int ExpirationMinutes = 30;
    private const string Audience = "MeLi-Clone-Users-Ms";
    private const string Issuer = "MeLi-Clone-Users-Ms";
    private readonly string _secretKey;
    private readonly string _cartMsSecretKey;
    
    public TokenService()
    {
        _secretKey = Environment.GetEnvironmentVariable("MeLi_Clone_users_ms_SECRET_KEY");
        _cartMsSecretKey = Environment.GetEnvironmentVariable("MeLi_Clone_cart_ms_SECRET_KEY");
        if(string.IsNullOrEmpty(_secretKey))
            throw new SystemException("Me Li Clone users ms secret key not set");
    }
    public string GenerateToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Name, user.Name),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
        };

        var token = new JwtSecurityToken(
            issuer: Issuer,
            audience: Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(ExpirationMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public void ValidateToken(string token)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));

        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = Issuer,
            ValidateAudience = true,
            ValidAudience = Audience,
            ValidateLifetime = true,
            IssuerSigningKey = key,
            ValidateIssuerSigningKey = true
        };
        try
        {
            tokenHandler.ValidateToken(token, validationParameters, out _);
        }
        catch (ArgumentNullException)
        {
            throw new UnauthorizedAccessException("Missing authentication");
        }
    }
    
    /*
    public void ValidateCartToken(string token)
    {
        var cartKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_cartMsSecretKey));

        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "MeLi-Clone-Cart-Ms",
            ValidateAudience = true,
            ValidAudience = "MeLi-Clone-Users-Ms",
            ValidateLifetime = true,
            IssuerSigningKey = cartKey,
            ValidateIssuerSigningKey = true
        };
        try
        {
            tokenHandler.ValidateToken(token, validationParameters, out _);
        }
        catch (ArgumentNullException)
        {
            throw new UnauthorizedAccessException("Missing authentication");
        }
    }
    */

    public int GetUserIdFromToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sid)?.Value;
        if (userId == null)
            throw new SecurityTokenException("Invalid token");
        
        return int.Parse(userId);
    }
}