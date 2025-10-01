
namespace Models.InputModels;

public class BookInputModel
{
    // ■ Name: string
    // ■ Description: string?
    // ■ NumberOfPages: int

    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int NumberOfPages { get; set; }

}