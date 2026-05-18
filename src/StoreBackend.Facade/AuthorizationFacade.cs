using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StoreBackend.Domain.Entities;
using StoreBackend.DomainService;
using StoreBackend.Dto;
using StoreBackend.Exceptions;

namespace StoreBackend.Facade;

public class AuthorizationFacade : IAuthorizationFacade
{
    private readonly IUserService userService;
    private readonly IConfiguration configuration;

    public AuthorizationFacade(IUserService userService, IConfiguration configuration)
    {
        this.userService = userService;
        this.configuration = configuration;
    }

    public async Task<AuthorizationResponseDto> AuthorizeAsync(AuthorizationRequestDto requestDto)
    {
        var user = await userService.GetByUserAndPassword(requestDto).ConfigureAwait(false);

        if (user == null)
        {
            throw new UnauthorizedResponseException();
        }

        var jwtSettings = configuration.GetSection("Jwt");
        var expirationMinutes = int.Parse(jwtSettings["ExpirationMinutes"]);

        var token = GenerateJwtToken(user, jwtSettings, expirationMinutes);

        return new AuthorizationResponseDto
        {
            BearerToken = token,
            ExpiresIn = DateTime.UtcNow.AddMinutes(expirationMinutes),
        };
    }

    private string GenerateJwtToken(User user, IConfigurationSection jwtSettings, int expirationMinutes)
    {
        var secret = jwtSettings["Secret"];
        var issuer = jwtSettings["Issuer"];
        var audience = jwtSettings["Audience"];

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Username),
            new("externalId", user.UserResourceId.ToString()),
        };

        claims.AddRange([.. user.UserRoles.Select(r => new Claim(ClaimTypes.Role, r.Role.Name))]); // grabs all roles assigned to a user and adds them as claims

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}