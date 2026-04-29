using StoreBackend.Dto;

namespace StoreBackend.Facade
{
    public interface IUserFacade
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> CreateAsync(CreateUserDto user);
        
    }
}