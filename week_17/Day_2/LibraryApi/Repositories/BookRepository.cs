using LibraryApi.Data;
using LibraryApi.Migrations;
using LibraryApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;


namespace LibraryApi.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _context;

    public BookRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> GetAllAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<Book> CreateAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<bool> UpdateAsync(int id, Book book)
    {
        var exiting = await _context.Books.FindAsync(id);

        if (exiting is null)
        {
            return false;
        }

        exiting.Title = book.Title;
        exiting.Author = book.Author;
        exiting.ISBN = book.ISBN;
        exiting.PublishedYear = book.PublishedYear;

        await _context.SaveChangesAsync();
        return true;

    }

    public async Task<bool> DeleteAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book is null)
        {
            return false;
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return true;
    }
}