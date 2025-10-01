
namespace Models.InputModels;

public class RegisterInputModel
{
    // ■ FullName: string
    // ■ EmailAddress: string
    // ■ Password: string
    // ■ ConfirmPassword: string
    public string FullName { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;
}