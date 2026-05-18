using StoreBackend.Api.Models.Responses;
using StoreBackend.Dto;
using StoreBackend.Models.Requests;

namespace StoreBackend.Api.Mappers;

public static class AuthorizationMapper
{
    public static AuthorizationRequestDto ToDto(this AuthorizationRequestModel model)
    {
        return new AuthorizationRequestDto
        {
            Username = model.Username,
            Password = model.Password,
        };
    }

    public static AuthorizationResponseModel ToResponse(this AuthorizationResponseDto dto)
    {
        return new AuthorizationResponseModel
        {
            BearerToken = dto.BearerToken,
            ExpiresIn = dto.ExpiresIn,
        };
    }
}