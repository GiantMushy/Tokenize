
namespace Models.Entities;

public class User
{
    // ■ Id: int
    // ■ FullName: string
    // ■ EmailAddress: string
    // ■ HashedPassword: string
    // ■ RegistrationDate: DateTime
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string HashedPassword { get; set; } = null!;
    public DateTime RegistrationDate { get; set; }
}