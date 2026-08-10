namespace BlogPlatformAPI.DTOs;

public class CommentDto
{
    public int Id { get; set; }
    public string CommenterName { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}