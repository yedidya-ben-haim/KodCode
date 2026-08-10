using System.ComponentModel.DataAnnotations;

namespace BlogPlatformAPI.Models;

public class Author
{
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string FullName { get; set; } = string.Empty;

    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    public DateTime JoinedDate { get; set; }

    public ICollection<Post> Posts { get; set; } = new List<Post>();

}