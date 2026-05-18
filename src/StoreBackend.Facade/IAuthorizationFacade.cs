using StoreBackend.Dto;

namespace StoreBackend.Facade;

public interface IAuthorizationFacade
{
    Task<AuthorizationResponseDto> AuthorizeAsync(AuthorizationRequestDto request);
}