using Microsoft.EntityFrameworkCore;
using StoreBackend.Domain.Entities;

namespace StoreBackend.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            return user;
        }

        public async Task<bool> HasUserByUsernameAsync(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username);
        }

        public async Task<bool> HasUserByEmailAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
    }
}