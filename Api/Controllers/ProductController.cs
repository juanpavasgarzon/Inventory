using Application.Services.Contracts;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductApplication _productApplication;

    public ProductController(ILogger<ProductController> logger, IProductApplication productApplication)
    {
        _logger = logger;
        _productApplication = productApplication;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<ActionResult<int>> Get()
    {
        try
        {
            return Task.FromResult<ActionResult<int>>(Ok());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while getting users");
            return Task.FromResult<ActionResult<int>>(StatusCode(StatusCodes.Status500InternalServerError, ex.Message));
        }
    }
}