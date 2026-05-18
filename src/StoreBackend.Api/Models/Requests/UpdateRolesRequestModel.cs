using System.ComponentModel.DataAnnotations;
using StoreBackend.Api.Enumerations;

namespace StoreBackend.Api.Models.Requests;

public class UpdateRolesRequestModel
{
    [Required]
    public required List<RoleAliases> Roles { get; set; } = [];
}