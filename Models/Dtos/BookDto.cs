
namespace Models.Dtos;

public class BookDto
{
    // ■ Id: int
    // ■ Name: string
    // ■ NumberOfPages: int
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int NumberOfPages { get; set; }
}