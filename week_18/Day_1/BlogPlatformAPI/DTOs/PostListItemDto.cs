namespace BlogPlatformAPI.DTOs;

public class PostListItemDto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string AuthorName { get; set; } = string.Empty;

    public DateTime PublishedDate { get; set; }

    public int CommentCount { get; set; }
}