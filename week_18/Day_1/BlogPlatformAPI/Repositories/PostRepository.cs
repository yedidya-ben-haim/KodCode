using BlogPlatformAPI.Data;
using BlogPlatformAPI.DTOs;
using BlogPlatformAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatformAPI.Repositories;

public class PostRepository : IPostRepository
{
    private readonly BlogPlatformDbContext _context;

    public PostRepository(BlogPlatformDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Post>> GetAllWithAuthorAndCommentsAsync()
    {
        return await _context.Posts
            .Include(p => p.Author)
            .Include(p => p.Comments)
            .ToListAsync();
    }

    public async Task<IEnumerable<Post>> GetPublishedPostsFilteredAsync(int? authorId, DateTime? fromDate,
        DateTime? tillDate)
    {
        var query = _context.Posts.Where(p => p.IsPublished == true).AsQueryable();

        if (authorId.HasValue)
        {
            query = query.Where(p => p.AuthorId == authorId.Value);
        }
        if (fromDate.HasValue)
        {
            query = query.Where(p => p.PublishedDate >= fromDate.Value);
        }
        if (tillDate.HasValue)
        {
            query = query.Where(p => p.PublishedDate <= tillDate.Value);
        }
        return await query.ToListAsync();
    }

    public async Task<IEnumerable<Post>> SortByPublishedDateOrTitleAsync(string sortBy, bool isDescending)
    {
        var query = _context.Posts.AsQueryable();

        var sortField = sortBy?.ToLower();

        switch (sortField)
        {
            case "title":
                query = isDescending
                    ? query.OrderByDescending(p => p.Title)
                    : query.OrderBy(p => p.Title);
            break;
            
            case "date":
                query = isDescending
                    ? query.OrderByDescending(p => p.PublishedDate)
                    : query.OrderBy(p => p.PublishedDate); 
                break;
        }

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<object>> GetPostsWithCountComment()
    {
        return await _context.Posts
            .Select(p => new
            {
                p.Title,
                commentCount = p.Comments.Count
            }).ToListAsync();
    }

    public async Task<IEnumerable<object>> GetAuthorWithCommentsCount()
    {
        var query = _context.Comments
            .GroupBy(c => new { c.Post.Author.Id, c.Post.Author.FullName })
            .Select(g => new
            {
                g.Key.FullName,
                TotalComments = g.Count()
            });
        return await query.ToListAsync();
    }

    public async Task<(IEnumerable<Post> posts, int totalPosts)> GetPagedAsync(int page, int pageSize)
    {
        var totalPosts = await _context.Posts.CountAsync();

        var posts = await _context.Posts
            .OrderBy(p => p.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (posts, totalPosts);
    }

    public async Task<PostDetailDto?> GetPostById(int id)
    {
        return await _context.Posts
            .Where(p => p.Id == id)
            .Select(p => new PostDetailDto
            {
                Id = p.Id,
                Title = p.Title,
                AuthorName = p.Author.FullName,
                Body = p.Body,
                PublishedDate = p.PublishedDate,
                Comments = p.Comments.Select(c =>
                    new CommentDto
                    {
                        Id = c.Id,
                        CommenterName = c.CommenterName,
                        Text = c.Text,
                        CreatedAt = c.CreatedAt
                    }).ToList()
            }).FirstOrDefaultAsync();
    }
}