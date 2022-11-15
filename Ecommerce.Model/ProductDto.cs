using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Model;

public class ProductDto
{
    public int Id { get; set; }

    [MinLength(2)]
    [MaxLength(30)]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Please write a meaningful description.")]
    public string Description { get; set; }

    public bool ShopFavourites { get; set; }
    public bool CustomerFavourites { get; set; }
    
    [Required]
    public string Color { get; set; }
    
    public string? ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime? UpdatedAt { get; set; } 
    
    [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
    public int CategoryId { get; set; }
    
    [ForeignKey("CategoryId")]
    public CategoryDto Category { get; set; }
    public ICollection<ProductPriceDto> ProductPrices { get; set; }
}