using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Model;

public class ProductPriceDto
{
    public int Id { get; set; }
    [Required]
    public int ProductId { get; set; }
    [Required]
    public string Size { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "The price must be greater than 1")]
    public double Price { get; set; }
}