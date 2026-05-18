using System;
using StoreBackend.Dto;

namespace StoreBackend.Facade;

public interface IUserFacade
{
    Task<List<UserDto>> GetAllAsync();
    Task<UserDto> CreateAsync(CreateUserDto user);
    Task<UserRolesDto> GetUserRolesAsync(Guid userId);
    Task<UserRolesDto> UpdateUserRolesAsync(Guid userId, UpdateRolesDto dto);
    Task DeleteUserRolesAsync(Guid userId);
}