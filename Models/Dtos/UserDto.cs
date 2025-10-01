
namespace Models.Dtos;

public class UserDto
{
    // ■ Id: int
    // ■ FullName: string
    // ■ EmailAddress: string
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
}