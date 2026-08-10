using BlogPlatformAPI.DTOs;
using BlogPlatformAPI.Models;

namespace BlogPlatformAPI.Repositories;

public interface IPostRepository
{
    Task<IEnumerable<Post>> GetAllWithAuthorAndCommentsAsync();
    Task<IEnumerable<Post>> GetPublishedPostsFilteredAsync(int? authorId, DateTime? fromDate, DateTime? tillDate);
    Task<IEnumerable<Post>> SortByPublishedDateOrTitleAsync(string sortBy, bool isDescending);
    Task<IEnumerable<object>> GetPostsWithCountComment();
    Task<IEnumerable<object>> GetAuthorWithCommentsCount();
    Task<(IEnumerable<Post> posts, int totalPosts)> GetPagedAsync(int page, int pageSize);
    Task<PostDetailDto?> GetPostById(int id);
}