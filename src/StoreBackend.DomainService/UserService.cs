using StoreBackend.Domain.Entities;
using StoreBackend.Dto;
using StoreBackend.Infrastructure;
using BCrypt.Net;

namespace StoreBackend.DomainService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();

            // Aquí va la regla de negocio si el profe la pide

            return users;
        }

        public async Task<User> CreateAsync(CreateUserDto user)
        {
            if (await _userRepository.HasUserByUsernameAsync(user.Username))
            {
                throw new Exceptions.BadRequestResponseException("Username is already taken");
            }
            if (await _userRepository.HasUserByEmailAsync(user.Email))
            {
                throw new Exceptions.BadRequestResponseException("Email is already taken");
            }

            var entity = new User
            {
                UserResourceId = Guid.NewGuid(),
                Name = user.Name,
                Username = user.Username,
                Email = user.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password)
            };
            return await _userRepository.CreateAsync(entity);
        }

    }
}