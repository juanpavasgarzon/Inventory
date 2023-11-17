using Api.Dtos;
using Application.Services.Contracts;
using Asp.Versioning;
using AutoMapper;
using Domain.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class SupplierController : ControllerBase
{
    private readonly ILogger<SupplierController> _logger;
    private readonly IMapper _mapper;
    private readonly ISupplierApplication _supplierApplication;

    public SupplierController(
        ILogger<SupplierController> logger,
        IMapper mapper,
        ISupplierApplication supplierApplication
    )
    {
        _logger = logger;
        _mapper = mapper;
        _supplierApplication = supplierApplication;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create(CreateSupplierDto dto)
    {
        try
        {
            var command = _mapper.Map<CreateSupplierCommand>(dto);
            var supplierId = await _supplierApplication.CreateSupplierAsync(command);
            return CreatedAtAction(nameof(Find), new { supplierId }, new { supplierId });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while creating user");
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
        }
    }

    [HttpGet("{supplierId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public Task<ActionResult> Find(int supplierId)
    {
        try
        {
            return Task.FromResult<ActionResult>(Ok());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while creating user");
            return Task.FromResult<ActionResult>(StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message }));
        }
    }
}