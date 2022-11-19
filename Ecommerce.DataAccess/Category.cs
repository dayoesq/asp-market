using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataAccess;

[Index(nameof(Name), IsUnique = true)]
public class Category
{
    public int Id { get; set; }

    [MinLength(2, ErrorMessage = "The name field cannot be shorter than '2' characters")]
    [MaxLength(30, ErrorMessage = "The name field cannot be shorter than '30' characters")]
    public string Name { get; set; }
    public DateTime? CreatedAt { get; set; }
}