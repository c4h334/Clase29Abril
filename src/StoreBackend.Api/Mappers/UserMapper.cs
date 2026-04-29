using System;
using System.Collections.Generic;
using System.Linq;
using StoreBackend.Api.Models.Requests;
using StoreBackend.Api.Models.Responses;
using StoreBackend.Domain.Entities;
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
            Username = user.Username,
            Name = user.Name,
            Email = user.Email
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

}