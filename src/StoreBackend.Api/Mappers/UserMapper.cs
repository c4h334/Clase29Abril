using StoreBackend.Api.Models.Requests;
using StoreBackend.Api.Models.Responses;
using StoreBackend.Dto;

namespace StoreBackend.Api.Mappers;

public class UserMapper
{
    public static List<UserResponseModel> ToModel(List<UserDto> users)
    {
        return users.Select(u => ToModel(u)).ToList();
    }

    public static UserResponseModel ToModel(UserDto user)
    {
        return new UserResponseModel
        {
            UserResourceId = user.UserResourceId,
            Name = user.Name,
            Username = user.Username,
            Email = user.Email,
        };
    }

    public static CreateUserDto ToDto(CreateUserRequestModel user)
    {
        return new CreateUserDto
        {
            Name = user.Name,
            Username = user.Username,
            Email = user.Email,
            Password = user.Password,
        };
    }

    public static UserRolesResponseModel ToDto(UserRolesDto dto)
    {
        return new UserRolesResponseModel
        {
            Roles = dto.Roles?.Select(r => RoleMapper.MapRoleNameToAlias(r)).ToList() ?? [],
        };
    }

    public static UpdateRolesDto ToDto(UpdateRolesRequestModel model)
    {
        return new UpdateRolesDto
        {
            Roles = model.Roles?.Distinct().Select(r => RoleMapper.MapRoleAliasToName(r)).ToList() ?? [],
        };
    }

    public static UserRolesResponseModel ToUserRolesResponseModel(UserRolesDto model)
    {
        return new UserRolesResponseModel
        {
            Roles = model.Roles?.Select(r => RoleMapper.MapRoleNameToAlias(r)).ToList() ?? [],
        };
    }
}