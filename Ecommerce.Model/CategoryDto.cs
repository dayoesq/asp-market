using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Model;

public class CategoryDto
{
    public int Id { get; set; }

    [MinLength(2, ErrorMessage = "The name field cannot be shorter than '2' characters")]
    [MaxLength(30, ErrorMessage = "The name field cannot be shorter than '30' characters")]
    public string Name { get; set; }
}