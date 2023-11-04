using Application.Services.Third.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ThirdController : ControllerBase
{
    private readonly ILogger<ThirdController> _logger;
    private readonly IThirdApplication _productApplication;

    public ThirdController(ILogger<ThirdController> logger, IThirdApplication productApplication)
    {
        _logger = logger;
        _productApplication = productApplication;
    }
}