using System;
using StoreBackend.Api.Enumerations;

namespace StoreBackend.Api.Models.Responses;

public class UserResponseModel
{
    public Guid UserResourceId { get; set; }
    public required string Name { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }

}