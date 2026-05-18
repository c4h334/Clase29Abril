using System.ComponentModel.DataAnnotations;

namespace StoreBackend.Models.Requests;

public class AuthorizationRequestModel
{
    [Required]
    [MaxLength(100)]
    public required string Username { get; set; }

    [Required]
    [MaxLength(255)]
    public required string Password { get; set; }
}