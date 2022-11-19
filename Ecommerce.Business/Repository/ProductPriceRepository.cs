using AutoMapper;
using Ecommerce.Business.Repository.IRepository;
using Ecommerce.DataAccess;
using Ecommerce.DataAccess.Data;
using Ecommerce.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Business.Repository;

public class ProductPriceRepository : IProductPriceRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<ProductPriceRepository> _logger;

    public ProductPriceRepository(ApplicationDbContext dbContext, IMapper mapper, ILogger<ProductPriceRepository> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ProductPriceDto> Create(ProductPriceDto productPriceDto)
    {
        try
        {
            var obj = _mapper.Map<ProductPriceDto, ProductPrice>(productPriceDto);
            var addedObj = _dbContext.Add(obj);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ProductPrice, ProductPriceDto>(addedObj.Entity);

        }
        catch (Exception e)
        {
            _logger.LogError("ProductPrice creation failed");
            throw new Exception(e.Message);
        }
    }

    public IEnumerable<ProductPriceDto> GetAll(int? id = null)
    {
        try
        {
            if (id != null && id > 0)
            {
                return _mapper.Map<IEnumerable<ProductPrice>, IEnumerable<ProductPriceDto>>
                    (_dbContext.ProductPrices.Where(a => a.ProductId == id));
            }
            return _mapper.Map<IEnumerable<ProductPrice>, IEnumerable<ProductPriceDto>>(_dbContext.ProductPrices);
        }
        catch (Exception e)
        {
            _logger.LogError("Failed to get product prices");
            throw new Exception(e.Message);
        }
    }

    public async Task<ProductPriceDto> Get(int id)
    {
        try
        {
            var obj = await _dbContext.ProductPrices.FirstOrDefaultAsync(a => a.Id == id);
            return obj != null ? _mapper.Map<ProductPrice, ProductPriceDto>(obj) : new ProductPriceDto();
        }
        catch (Exception e)
        {
            _logger.LogError("Failed to get product price");
            throw new Exception(e.Message);
        }
    }

    public async Task<ProductPriceDto> Update(ProductPriceDto productPriceDto)
    {
        try
        {
            var obj = await _dbContext.ProductPrices.FirstOrDefaultAsync(a => a.Id == productPriceDto.Id);
            if (obj == null) return productPriceDto;
            obj.Price = productPriceDto.Price;
            obj.Size = productPriceDto.Size;
            obj.ProductId = productPriceDto.ProductId;
            _dbContext.ProductPrices.Update(obj);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ProductPrice, ProductPriceDto>(obj);
        }
        catch (Exception e)
        {
            _logger.LogError("Failed to update product price");
            throw new Exception(e.Message);
        }
    }

    public async Task<int> Delete(int id)
    {
        try
        {
            var obj = await _dbContext.ProductPrices.FirstOrDefaultAsync(a => a.Id == id);
            if (obj == null) return 0;
            _dbContext.ProductPrices.Remove(obj);
            return await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError("Failed to delete product price");
            throw new Exception(e.Message);
        }
    }
}