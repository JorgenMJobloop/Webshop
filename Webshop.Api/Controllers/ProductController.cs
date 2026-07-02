using Microsoft.AspNetCore.Mvc;
using Webshop.Api.Services;
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetProductsAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequest request)
    {
        var product = await _productService.CreateProductAsync(request.name, request.price, request.stockQuantity);

        return CreatedAtAction(nameof(GetAll), new { id = product.Id }, product);
    }
}