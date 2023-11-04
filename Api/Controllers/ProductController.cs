using Application.Services.Product.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductApplication _productApplication;

    public ProductController(ILogger<ProductController> logger, IProductApplication productApplication)
    {
        _logger = logger;
        _productApplication = productApplication;
    }
}