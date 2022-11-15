using Ecommerce.Model;

namespace Ecommerce.Client.Service.IService;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAll();
    Task<ProductDto> Get(int productId);
}