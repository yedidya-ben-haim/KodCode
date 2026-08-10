namespace BlogPlatformAPI.DTOs;

public class PostDetailDto
{
    public int Id { get; set; }
        
    public string Title { get; set; } = string.Empty;
        
    public string Body { get; set; } = string.Empty;
        
    public string AuthorName { get; set; } = string.Empty;
        
    public DateTime PublishedDate { get; set; }
        
    public List<CommentDto> Comments { get; set; } = new();
}