using Ecommerce.Model;

namespace Ecommerce.Business.Repository.IRepository;

public interface ICategoryRepository
{
    Task<CategoryDto> Create(CategoryDto categoryDto);
    Task<IEnumerable<CategoryDto>> GetAll();
    Task<CategoryDto> Get(int id);
    Task<CategoryDto> Update(CategoryDto categoryDto);
    Task<int> Delete(int id);
    
}