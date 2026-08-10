using BlogPlatformAPI.DTOs;
using BlogPlatformAPI.Models;
using BlogPlatformAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogPlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostRepository _repository;

    public PostsController(IPostRepository repository)
    {
        _repository = repository;
    }

    //GET api/posts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetAllWithAuthorAndComments()
    {
        return Ok(await _repository.GetAllWithAuthorAndCommentsAsync());
    }
    
    //GET api/posts/filter
    [HttpGet("filter")]
    public async Task<ActionResult<IEnumerable<Post>>> GetPublishedPostsFiltered(int? authorId, DateTime? fromDate,
        DateTime? tillDate)
    {
        return Ok(await _repository.GetPublishedPostsFilteredAsync(authorId, fromDate, tillDate));
    }
    
    //GET api/posts/sort
    [HttpGet("sort")]
    public async Task<ActionResult<IEnumerable<Post>>> SortByPublishedDateOrTitle(string sortBy, bool isDescending)
    {
        return Ok(await _repository.SortByPublishedDateOrTitleAsync(sortBy, isDescending));
    }
    
    //GET api/posts/comment-count
    [HttpGet("comment-count")]
    public async Task<ActionResult<IEnumerable<object>>> GetPostsWithCountComment()
    {
        return Ok(await _repository.GetPostsWithCountComment());
    }
    
    //GET api/posts/author-comments
    [HttpGet("author-comments")]
    public async Task<ActionResult<IEnumerable<object>>> GetAuthorCommentsCount()
    {
        return Ok(await _repository.GetAuthorWithCommentsCount());
    }
    
    //GET api/posts/page
    [HttpGet("page")]
    public async Task<ActionResult<object>> GetPage(int page = 1, int pageSize = 10)
    {
        var (posts, totalPost) = await _repository.GetPagedAsync(page, pageSize);
        
        return Ok(new {posts, totalPost, page, pageSize});
    }
    
    //GET api/posts/Id
    [HttpGet("{id}")]
    public async Task<ActionResult<PostDetailDto?>> GetPostById(int id)
    {
        var post = await _repository.GetPostById(id);
        if (post == null)
        {
            return NotFound();
        }

        return Ok(post);
    }
    
    
}