
using System.ComponentModel.DataAnnotations;

namespace Models.InputModels;

public class RegisterInputModel
{
    // ■ FullName: string
    // ■ EmailAddress: string
    // ■ Password: string
    // ■ ConfirmPassword: string

    [Required]
    [MinLength(3, ErrorMessage = "Full name should be at least 3 characters long.")]
    public string FullName { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; } = null!;

    [Required]
    [MinLength(6)]
    public string Password { get; set; } = null!;

    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = null!;
}