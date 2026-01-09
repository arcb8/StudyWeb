using Microsoft.AspNetCore.Mvc;
using StudyWeb.Contracts.Products;
using StudyWeb.Services.Products;

namespace StudyWeb.Controllers;


[ApiController]
[Route("products")]
public class ProductsController : ControllerBase
{
    private IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_productService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_productService.Get(id));
    }

    [HttpPost]
    public IActionResult Create(CreateProductRequest request)
    {
        return Ok(_productService.Create(request));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok(_productService.Delete(id));
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateProductRequest request)
    {
        return Ok(_productService.Update(id, request));
    }
}