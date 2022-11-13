using Ecommerce.Model;

namespace Ecommerce.Business.Repository.IRepository;

public interface IProductPriceRepository
{
    Task<ProductPriceDto> Create(ProductPriceDto productPriceDto);
    IEnumerable<ProductPriceDto> GetAll(int? id);
    Task<ProductPriceDto> Get(int id);
    Task<ProductPriceDto> Update(ProductPriceDto productPriceDto);
    Task<int> Delete(int id);
}