using AutoMapper;
using Ecommerce.Business.Repository.IRepository;
using Ecommerce.Common.Util;
using Ecommerce.DataAccess;
using Ecommerce.DataAccess.Data;
using Ecommerce.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Business.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<ProductRepository> _logger;

    public ProductRepository(ApplicationDbContext dbContext, IMapper mapper, ILogger<ProductRepository> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ProductDto> Create(ProductDto productDto)
    {
        try
        {
            var obj = _mapper.Map<ProductDto, Product>(productDto);
            obj.CreatedAt = DateTime.UtcNow;
            obj.Name = Util.Capitalize(productDto.Name);
            var addedObj = _dbContext.Products.Add(obj);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(addedObj.Entity);
        }
        catch (Exception e)
        {
            _logger.LogError("Product creation failed");
            throw new Exception(e.Message);
        }
    }

    public async Task<ProductDto> Update(ProductDto productDto)
    {
        var obj = await _dbContext.Products.FirstOrDefaultAsync(a => a.Id == productDto.Id);
        if (obj == null) return productDto;
        obj.Name = Util.Capitalize(productDto.Name);
        obj.Description = productDto.Description;
        obj.ShopFavourites = productDto.ShopFavourites;
        obj.CustomerFavourites = productDto.CustomerFavourites;
        obj.Color = Util.Capitalize(productDto.Color);
        obj.ImageUrl = productDto.ImageUrl;
        obj.UpdatedAt = DateTime.UtcNow;
        obj.CategoryId = productDto.CategoryId;

        _dbContext.Products.Update(obj);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<Product, ProductDto>(obj);
    }

    public async Task<int> Delete(int id)
    {
        var obj = await _dbContext.Products.FirstOrDefaultAsync(a => a.Id == id);
        if (obj == null) return 0;
        _dbContext.Products.Remove(obj);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<ProductDto> Get(int id)
    {
        var obj = await _dbContext.Products
            .Include(a => a.Category)
            .Include(a => a.ProductPrices)
            .FirstOrDefaultAsync(a => a.Id == id);
        return obj != null ? _mapper.Map<Product, ProductDto>(obj) : new ProductDto();
    }

    public async Task<IEnumerable<ProductDto>> GetAll()
    {
        var categories = await _dbContext.Products
            .Include(a => a.Category)
            .Include(a => a.ProductPrices)
            .ToListAsync();
        return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(categories);
    }
}