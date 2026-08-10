using System.ComponentModel.DataAnnotations;

namespace BlogPlatformAPI.Models;

public class Post
{
    public int Id { get; set; }
    
    [Required]
    public int AuthorId { get; set; }

    public Author Author { get; set; } = null!;

    [Required]
    [StringLength(20)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string Body { get; set; } = string.Empty;
    
    [Required]
    public DateTime PublishedDate { get; set; }
    
    [Required]
    public bool IsPublished { get; set; }

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}