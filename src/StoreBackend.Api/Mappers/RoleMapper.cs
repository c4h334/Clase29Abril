using System;
using Microsoft.AspNetCore.Http.HttpResults;
using StoreBackend.Api.Enumerations;
using StoreBackend.DomainService;
using StoreBackend.Exceptions;
using StoreBackend.Api.Security;

namespace StoreBackend.Api.Mappers;

public static class RoleMapper
{
    public static string MapRoleAliasToName(RoleAliases alias)
    {
        return alias switch
        {
            RoleAliases.ADM => RoleNames.Administrator,
            RoleAliases.CUST => RoleNames.Customer,
            RoleAliases.SP => RoleNames.Support,
            _ => throw new BadRequestResponseException("Invalid role provided.")
        };
    }

    public static RoleAliases MapRoleNameToAlias(string name)
    {
        return name switch
        {
            RoleNames.Administrator => RoleAliases.ADM,
            RoleNames.Customer => RoleAliases.CUST,
            RoleNames.Support => RoleAliases.SP,
            _ => throw new BadRequestResponseException("Invalid role provided.")
        };
    }
}