using Ecommerce.Model;

namespace Ecommerce.Client.ViewModels;

public class ShoppingCart
{
    public int ProductId { get; set; }
    public ProductDto Product { get; set; }
    public int ProductPriceId { get; set; }
    public ProductPriceDto ProductPrice { get; set; }
    public int Count { get; set; }
}