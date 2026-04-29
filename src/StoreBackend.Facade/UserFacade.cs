using StoreBackend.DomainService;
using StoreBackend.Dto;
using StoreBackend.Facade.Mappers;
using StoreBackend.Infrastructure;

namespace StoreBackend.Facade
{
    public class UserFacade : IUserFacade
    {
        private readonly IUserService _userService;
        private readonly AppDbContext context;

        public UserFacade(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();

            return users.Select(user => new UserDto
            { 
                Name = user.Name,
                Username = user.Username,
                Email = user.Email
            });
        }

        public async Task<UserDto> CreateAsync(CreateUserDto user)
        {
            var entity = await _userService.CreateAsync(user);
            await context.SaveChangesAsync();
            return UserMapper.ToDto(entity);
        }
    }
}