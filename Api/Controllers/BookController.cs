using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Models.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Api.Controllers;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
    // i. GetAllBooks()
    // ii. GetBookById(int id)
    // iii. CreateBook(BookInputModel inputModel)
    // iv. UpdateBookById(int id, BookInputModel inputModel)
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("", Name = "GetAllBooks")]
    public IActionResult GetAllBooks()
    {
        return Ok(_bookService.GetAllBooks());
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("{id:int}", Name = "GetBookById")]
    public IActionResult GetBookById(int id)
    {
        try
        {
            return Ok(_bookService.GetBookById(id));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPost("", Name = "CreateBook")]
    public IActionResult CreateBook([FromBody] BookInputModel inputModel)
    {
        try
        {
            var BookId = _bookService.CreateBook(inputModel);
            return CreatedAtRoute("GetBookById", new { id = BookId }, inputModel);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPut("{id:int}", Name = "UpdateBookById")]
    public IActionResult UpdateBookById(int id, [FromBody] BookInputModel inputModel)
    {
        try
        {
            _bookService.UpdateBookById(id, inputModel);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}