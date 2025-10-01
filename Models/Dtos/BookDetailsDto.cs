
namespace Models.Dtos;

public class BookDetailsDto
{
    // ■ Id: int
    // ■ Name: string
    // ■ Description: string?
    // ■ NumberOfPages: int
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int NumberOfPages { get; set; }
}