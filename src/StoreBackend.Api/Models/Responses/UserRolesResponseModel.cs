using StoreBackend.Api.Enumerations;

namespace StoreBackend.Api.Models.Responses;

public class UserRolesResponseModel
{
    public List<RoleAliases> Roles { get; set; } = [];
}