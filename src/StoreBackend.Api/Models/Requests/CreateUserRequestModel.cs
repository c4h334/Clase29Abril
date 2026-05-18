using System;
using System.ComponentModel.DataAnnotations;
using StoreBackend.Api.Enumerations;

namespace StoreBackend.Api.Models.Requests;

public class CreateUserRequestModel
{
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }


    [Required]
    [MaxLength(50)]
    public required string Username { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Email { get; set; }

    [Required]
    [MaxLength(255)]
    [RegularExpression(
    @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
    ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character."
)]
    public required string Password { get; set; }
}