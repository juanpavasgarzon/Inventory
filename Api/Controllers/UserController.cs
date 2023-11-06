using Asp.Versioning;
using Api.Dtos;
using Application.Services.Contracts;
using Domain.Commands;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserApplication _userApplication;

    public UserController(ILogger<UserController> logger, IUserApplication userApplication)
    {
        _logger = logger;
        _userApplication = userApplication;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> Create(CreateUserDto dto)
    {
        try
        {
            var command = new CreateUserCommand(dto.Username, dto.Password, dto.PasswordConfirm);
            var user = await _userApplication.CreateUserAsync(command);
            return CreatedAtAction(nameof(Find), new { userId = user.Id }, new { userId = user.Id });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while creating user");
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> Inactivate(InactivateUserDto dto)
    {
        try
        {
            var command = new InactivateUserCommand(dto.UserId);
            var user = await _userApplication.InactivateUserAsync(command);
            return CreatedAtAction(nameof(Find), new { userId = user.Id }, new { userId = user.Id });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while updating user");
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<User>> Find(int userId)
    {
        try
        {
            var productType = await _userApplication.FindUserAsync(new FindUserQuery(userId));
            return Ok(productType);
        }
        catch (UserNotFoundException ex)
        {
            _logger.LogError(ex, "User not found");
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while getting a user");
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}