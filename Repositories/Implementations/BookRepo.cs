using Models.Dtos;
using Models.InputModels;
using Repositories.Contexts;
using Repositories.Interfaces;

namespace Repositories.Implementations;

public class BookRepo : IBookRepo
{
    private readonly TokenizeDbContext _dbContext;
    public BookRepo(TokenizeDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public BookDto[] GetAllBooks()
    {
        var books = _dbContext.Books.Select(b => new BookDto
        {
            Id = b.Id,
            Name = b.Name,
            NumberOfPages = b.NumberOfPages
        }).ToArray();

        return books;
    }

    public BookDetailsDto GetBookById(int bookId)
    {
        var book = _dbContext.Books
            .Where(b => b.Id == bookId)
            .Select(b => new BookDetailsDto
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
                NumberOfPages = b.NumberOfPages
            })
            .FirstOrDefault();

        if (book == null)
        {
            throw new KeyNotFoundException("Book not found.");
        }

        return book;
    }

    public int CreateBook(BookInputModel model)
    {
        var newBook = new Models.Entities.Book
        {
            Name = model.Name,
            Description = model.Description,
            NumberOfPages = model.NumberOfPages
        };
        _dbContext.Books.Add(newBook);
        _dbContext.SaveChanges();
        return newBook.Id;
    }

    public void UpdateBookById(int bookId, BookInputModel book)
    {
        var existingBook = _dbContext.Books.FirstOrDefault(b => b.Id == bookId);
        if (existingBook == null)
        {
            throw new KeyNotFoundException("Book not found.");
        }

        existingBook.Name = book.Name;
        existingBook.Description = book.Description;
        existingBook.NumberOfPages = book.NumberOfPages;

        _dbContext.SaveChanges();
    }
}