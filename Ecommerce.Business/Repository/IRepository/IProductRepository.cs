using Ecommerce.Model;

namespace Ecommerce.Business.Repository.IRepository;

public interface IProductRepository
{
    Task<ProductDto> Create(ProductDto productDto);
    Task<ProductDto> Update(ProductDto productDto);
    Task<int> Delete(int id);
    Task<ProductDto> Get(int id);
    Task<IEnumerable<ProductDto>> GetAll();
}