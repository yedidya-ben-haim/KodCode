using LibraryApi.Models;
using LibraryApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookRepository _bookRepository;

    public BooksController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetAll()
    {
        var books =  await _bookRepository.GetAllAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetById(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public async Task<ActionResult<Book>> Create(Book book)
    {
        var createdBook = await _bookRepository.CreateAsync(book);
        return CreatedAtAction(
            nameof(GetById),
            new { id = createdBook.Id },
            createdBook);
    }

    [HttpPut]
    public async Task<ActionResult<bool>> Update(int id, Book book)
    {
        var succses = await _bookRepository.UpdateAsync(id, book);
        if (!succses)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        var deleted = await _bookRepository.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return true;
    }
}