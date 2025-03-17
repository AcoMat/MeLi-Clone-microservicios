using System.Text.Json;
using MeLi_Clone_users_ms.Application.Interfaces;
using MeLi_Clone_users_ms.Domain.DTOs;
using MeLi_Clone_users_ms.Domain.Models;
using MeLi_Clone_users_ms.Infrastructure.Interfaces;

namespace MeLi_Clone_users_ms.Application.Services
{
    public class AuthService : IAuthService
    {    
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        async Task<User> IAuthService.RegisterUser(RegisterDTO registerDTO)
        {
            var existingUser = await _userRepository.GetUserByEmail(registerDTO.Email);

            if(existingUser != null)
            {
                throw new Exception("User already exists ");
            }

            var newUser = new User
            {
                Name = registerDTO.Name,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                PasswordHash = registerDTO.Password, //TODO: HASHEAR PASSWORD
                ImageURL = registerDTO.ImageURL
            };
            return await _userRepository.AddUser(newUser);
        } 

        Task<User> IAuthService.Login(LoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }
    }
}
