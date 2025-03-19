using MeLi_Clone_users_ms.Application.Interfaces;
using MeLi_Clone_users_ms.Domain.DTOs;
using MeLi_Clone_users_ms.Domain.Models;
using MeLi_Clone_users_ms.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace MeLi_Clone_users_ms.Application.Services
{
    public class UsersService : IUsersService
    {    
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        async Task<User> IUsersService.RegisterUser(RegisterDto registerDTO)
        {
            var existingUser = await _usersRepository.GetUserByEmail(registerDTO.Email);

            if(existingUser != null)
            {
                throw new ArgumentException("Email already in use");
            }
            
            var hashedPassword = new PasswordHasher<User>().HashPassword(null,registerDTO.Password);
            var newUser = new User
            {
                Name = registerDTO.Name,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                PasswordHash = hashedPassword,
                ImageURL = registerDTO.ImageURL
            };

            return await _usersRepository.AddUser(newUser);
        } 

        async Task<User> IUsersService.Login(LoginDto loginDTO)
        {
            var existingUser = await _usersRepository.GetUserByEmail(loginDTO.Email);
            if (existingUser == null)
                throw new ArgumentException("User not found");
            var verificationResult = new PasswordHasher<User>().VerifyHashedPassword(null, existingUser.PasswordHash, loginDTO.Password);
            if (verificationResult != PasswordVerificationResult.Success)
            {
                throw new ArgumentException("The email or password is incorrect");
            } 
            return existingUser;
        }
        
        async Task<User> IUsersService.GetUser(int id)
        {
            var user = await _usersRepository.GetUserById(id);
            if (user == null)
                throw new ArgumentException("User not found");
            return user;
        }

        public async Task<User> AddLikedProduct(int userId, int productId)
        {
            var user = await _usersRepository.GetUserById(userId);
            if (user!.FavoriteProducts.Contains(productId))
            {
                user!.FavoriteProducts.Remove(user.FavoriteProducts.First(id => id == productId));
            }
            else
            {
                user!.FavoriteProducts.Add(productId);
            }
            return await _usersRepository.UpdateUser(user);
        }
        
        public async Task<User> AddPurchase(PurchaseDto productDto)
        {
            throw new NotImplementedException();
            /*
            var user = await _usersRepository.GetUserById(productDto.UserId);
            var purchase = new Purchase
            {
                UserId = productDto.UserId,
                ProductsIds = productDto.ProductsIds,
                PurchaseDate = DateTime.Now,
                PurchasePrice = productDto.PurchasePrice
            };
            user!.PurchaseHistory.Add(purchase);

            return await _usersRepository.UpdateUser(user);
            */
        }
    }
}
