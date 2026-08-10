using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Model;

public class Product
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public decimal Price { get; set; }
    
    public int StockQuantity { get; set; }
    
    [Required]
    public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;
 
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}