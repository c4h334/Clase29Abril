using System;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto;

namespace StoreBackend.Facade.Mappers;

public class UserMapper
{
    public static List<UserDto> ToDto(List<User> users)
    {
        return users.Select(u => ToDto(u)).ToList();
    }

    public static UserDto ToDto(User user)
    {
        return new UserDto
        {
            UserResourceId = user.UserResourceId,
            Name = user.Name,
            Username = user.Username,
            Email = user.Email,
        };
    }

    public static UserRolesDto ToUserRolesDto(User user)
    {
        return new UserRolesDto
        {
            Roles = user.UserRoles?.Select(ur => ur.Role.Name).ToList() ?? [],
        };
    }
}