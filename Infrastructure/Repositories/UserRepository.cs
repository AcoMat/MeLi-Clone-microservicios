using MeLi_Clone_users_ms.Domain.Models;
using MeLi_Clone_users_ms.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeLi_Clone_users_ms.Infrastructure.Repositories
{ 
    public class UserRepository : IUserRepository
    {
        private readonly UsersContext _context; 
        
        public UserRepository(UsersContext context)
        {
            _context = context;
        }
        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);;
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateUser(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser == null)
                return null;
            
            
            _context.Entry(existingUser).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
            return existingUser;
        }
        
        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                throw new NullReferenceException("User not found");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

    }
}
