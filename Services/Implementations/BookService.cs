using Models.Dtos;
using Models.InputModels;
using Services.Interfaces;

namespace Services.Implementations;

public class BookService : IBookService
{
    // i. GetAllBooks: BookDto[]
    // ii. GetBookById: BookDetailsDto
    // iii. CreateBook: int
    // iv. UpdateBookById: void

    public BookDto[] GetAllBooks()
    {
        // Logic to retrieve all books
        throw new NotImplementedException();
    }
    public BookDetailsDto GetBookById(int id)
    {
        // Logic to retrieve a book by its ID
        throw new NotImplementedException();
    }
    public int CreateBook(BookInputModel inputModel)
    {
        // Logic to create a new book
        throw new NotImplementedException();
    }
    public void UpdateBookById(int id, BookInputModel inputModel)
    {
        // Logic to update an existing book by its ID
        throw new NotImplementedException();
    }
}