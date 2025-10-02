using Models.Dtos;
using Models.InputModels;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations;

public class BookService : IBookService
{
    private readonly IBookRepo _bookRepo;
    public BookService(IBookRepo bookRepo)
    {
        _bookRepo = bookRepo;
    }
    // i. GetAllBooks: BookDto[]
    // ii. GetBookById: BookDetailsDto
    // iii. CreateBook: int
    // iv. UpdateBookById: void

    public BookDto[] GetAllBooks()
    {
        return _bookRepo.GetAllBooks();
    }
    public BookDetailsDto GetBookById(int id)
    {
        return _bookRepo.GetBookById(id);
    }
    public int CreateBook(BookInputModel inputModel)
    {
        return _bookRepo.CreateBook(inputModel);
    }
    public void UpdateBookById(int id, BookInputModel inputModel)
    {
        _bookRepo.UpdateBookById(id, inputModel);
    }
}