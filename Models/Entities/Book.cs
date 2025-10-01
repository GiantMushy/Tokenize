
namespace Models.Entities;

public class Book
{
    // ■ Id: int
    // ■ Name: string
    // ■ Description: string?
    // ■ NumberOfPages: int
    // ■ CreatedDate: DateTime
    // ■ ModifiedDate: DateTime?
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int NumberOfPages { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}