using Ecommerce.Client.ViewModels;

namespace Ecommerce.Client.Service.IService;

public interface ICartService
{
    public event Action OnChange;
    Task DecrementCart(ShoppingCart shoppingCart);
    Task IncrementCart(ShoppingCart shoppingCart);
}