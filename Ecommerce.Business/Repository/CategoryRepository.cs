using AutoMapper;
using Ecommerce.Business.Repository.IRepository;
using Ecommerce.Common.Util;
using Ecommerce.DataAccess;
using Ecommerce.DataAccess.Data;
using Ecommerce.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Business.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public CategoryRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<CategoryDto> Create(CategoryDto categoryDto)
    {
        try
        {
            var obj = _mapper.Map<CategoryDto, Category>(categoryDto);
            obj.CreatedAt = DateTime.UtcNow;
            obj.Name = Util.Capitalize(obj.Name);
            var addedObj = _dbContext.Categories.Add(obj);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Category, CategoryDto>(addedObj.Entity);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

    }

    public async Task<CategoryDto> Update(CategoryDto categoryDto)
    {
        var obj = await _dbContext.Categories.FirstOrDefaultAsync(a => a.Id == categoryDto.Id);
        if (obj == null) return categoryDto;
        obj.Name = Util.Capitalize(categoryDto.Name);
        _dbContext.Categories.Update(obj);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<Category, CategoryDto>(obj);

    }
    
    public async Task<int> Delete(int id)
    {
        var obj = await _dbContext.Categories.FirstOrDefaultAsync(a => a.Id == id);
        if (obj == null) return 0;
        _dbContext.Categories.Remove(obj);
        return await _dbContext.SaveChangesAsync();

    }

    public async Task<CategoryDto> Get(int id)
    {
        var obj = await _dbContext.Categories.FirstOrDefaultAsync(a => a.Id == id);
        return obj != null ? _mapper.Map<Category, CategoryDto>(obj) : new CategoryDto();
    }

    public async Task<IEnumerable<CategoryDto>> GetAll()
    {
        var categories = await _dbContext.Categories.ToListAsync();
        return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);
    }
}