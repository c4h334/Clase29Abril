namespace StoreBackend.Api.Models.Responses;

public class UserResponseModel
{
    public Guid UserResourceId { get; set; }
    public string? Username { get; set; }

    public string? Name { get; set; }
    public string? Email { get; set; }
}
