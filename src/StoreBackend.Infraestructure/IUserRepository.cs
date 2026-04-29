using StoreBackend.Domain.Entities;

namespace StoreBackend.Infrastructure
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> CreateAsync(User user);
        Task<bool> HasUserByUsernameAsync(string username);
        Task<bool> HasUserByEmailAsync(string email);
    }
}