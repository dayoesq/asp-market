using Ecommerce.Model;

namespace Ecommerce.Business.Repository.IRepository;

public interface ICategoryRepository
{
    public Task<CategoryDto> Create(CategoryDto categoryDto);
    public Task<IEnumerable<CategoryDto>> GetAll();
    public Task<CategoryDto> Get(int id);
    public Task<CategoryDto> Update(CategoryDto categoryDto);
    public Task<int> Delete(int id);
    
}