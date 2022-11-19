using Ecommerce.Business.Repository.IRepository;
using Ecommerce.Model;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _productRepository.GetAll());
    }

    [HttpGet("{productId:int}")]
    public async Task<IActionResult> GetAll(int? productId)
    {
        if (productId is null or 0)
        {
            return BadRequest(new ErrorModelDto
            {
                ErrorMessage = "Invalid id",
                StatusCode = StatusCodes.Status400BadRequest
            });
        }

        var product = await _productRepository.Get(productId.Value);

        return Ok(product);
    }


}