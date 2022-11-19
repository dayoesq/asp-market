using Ecommerce.Client.Service.IService;
using Ecommerce.Model;
using Newtonsoft.Json;

namespace Ecommerce.Client.Service;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly string _baseServerUrl;

    public ProductService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _baseServerUrl = _configuration.GetSection("BaseServerUrl").Value;

    }

    public async Task<IEnumerable<ProductDto>> GetAll()
    {
        var response = await _httpClient.GetAsync("/api/product");
        if (!response.IsSuccessStatusCode) return new List<ProductDto>();
        var content = await response.Content.ReadAsStringAsync();
        var products = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(content);
        var productDtos = products.ToList();
        foreach (var prod in productDtos)
        {
            prod.ImageUrl = _baseServerUrl + prod.ImageUrl;
        }
        return productDtos;

    }

    public async Task<ProductDto> Get(int productId)
    {
        var response = await _httpClient.GetAsync($"/api/Product/{productId}");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            var errorModel = JsonConvert.DeserializeObject<ErrorModelDto>(content);
            throw new Exception(errorModel.ErrorMessage);
        }
        var product = JsonConvert.DeserializeObject<ProductDto>(content);
        return product;
    }
}