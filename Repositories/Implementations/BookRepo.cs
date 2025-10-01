using Models.Dtos;
using Models.InputModels;
using Repositories.Interfaces;

namespace Repositories.Implementations;

public class BookRepo : IBookRepo
{
    public BookDto[] GetAllBooks()
    {
        // Implementation for retrieving all books
        throw new NotImplementedException();
    }

    public BookDetailsDto GetBookById(int bookId)
    {
        // Implementation for retrieving a book by its ID
        throw new NotImplementedException();
    }

    public int CreateBook(BookInputModel model)
    {
        // Implementation for creating a new book
        throw new NotImplementedException();
    }

    public void UpdateBookById(int bookId, BookInputModel book)
    {
        // Implementation for updating a book by its ID
        throw new NotImplementedException();
    }
}