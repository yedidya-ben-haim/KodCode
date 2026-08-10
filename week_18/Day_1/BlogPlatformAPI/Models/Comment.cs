using System.ComponentModel.DataAnnotations;

namespace BlogPlatformAPI.Models;

public class Comment
{
    public int Id { get; set; }
    
    [Required]
    public int PostId { get; set; }

    public Post Post { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string CommenterName { get; set; } = string.Empty;

    [Required]
    [StringLength(1000)]
    public string Text { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; }
    
}