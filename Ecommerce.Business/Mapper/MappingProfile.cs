using AutoMapper;
using Ecommerce.Model;
using Ecommerce.DataAccess;

namespace Ecommerce.Business.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<ProductPrice, ProductPriceDto>().ReverseMap();
    }
}