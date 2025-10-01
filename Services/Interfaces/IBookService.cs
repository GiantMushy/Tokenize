using Models.Dtos;
using Models.InputModels;

namespace Services.Interfaces;

public interface IBookService
{
    // i. GetAllBooks: BookDto[]
    // ii. GetBookById: BookDetailsDto
    // iii. CreateBook: int
    // iv. UpdateBookById: void

    BookDto[] GetAllBooks();
    BookDetailsDto GetBookById(int id);
    int CreateBook(BookInputModel inputModel);
    void UpdateBookById(int id, BookInputModel inputModel);
}