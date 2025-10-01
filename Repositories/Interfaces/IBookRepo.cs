using Models.Dtos;
using Models.InputModels;

namespace Repositories.Interfaces;
public interface IBookRepo
{
    BookDto[] GetAllBooks();
    BookDetailsDto GetBookById(int bookId);
    int CreateBook(BookInputModel book);
    void UpdateBookById(int bookId, BookInputModel book);
}