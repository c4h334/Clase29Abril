namespace StoreBackend.Api.Models.Responses;

public class AuthorizationResponseModel
{
    public required string BearerToken { get; set; }
    public DateTime ExpiresIn { get; set; }
}