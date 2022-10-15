using System.Net;
using ElectronicBoard.AppServices.Services.User;
using ElectronicBoard.Contracts;
using ElectronicBoard.Contracts.Dto;
using ElectronicBoard.Contracts.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicBoard.Api.Controllers;

/// <summary>
/// Работа с пользователем.
/// </summary>
[ApiController]
[Produces("application/json")]
[Route("v1/users")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }
    
    /// <summary>
    /// Возвращает коллекцию пользователей.
    /// </summary>
    /// <returns>Коллекция пользователей <see cref="UserDto"/>.</returns>
    [Authorize(Roles="Admin")]
    [HttpGet(Name = "GetUsers")]
    [ProducesResponseType(typeof(IReadOnlyCollection<UserDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll([FromQuery]UserFilterRequest userFilter, CancellationToken cancellation)
    {
        return Ok(await _userService.GetAllUsers(userFilter, cancellation));
    }
    
    /// <summary>
    /// Возвращает пользователя по Id.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <returns>Пользователь <see cref="UserDto"/>.</returns>
    [HttpGet("{userId:int}", Name = "GetUserById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById(int userId, CancellationToken cancellation)
    {
        return Ok(await _userService.GetUserById(userId, cancellation));
    }

    /// <summary>
    /// Добавляет нового пользователя.
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [HttpPost(Name = "CreateUser")]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> Create([FromBody] UserDto model, CancellationToken cancellation)
    {
        model = await _userService.CreateUser(model, cancellation);
        return CreatedAtAction("GetById", new { userId = model.Id }, model);
    }
    
    /// <summary>
    /// Обновляет данные пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="userDto">Пользователь.</param>
    [Authorize]
    [HttpPut("{userId:int}", Name = "UpdateUser")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Update(int userId, [FromBody]UserDto userDto, CancellationToken cancellation)
    {
        await _userService.UpdateUser(userId, userDto, cancellation);
        return Ok();
    }
    
    /// <summary>
    /// Удаляет пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    [Authorize]
    [HttpDelete("{userId:int}", Name = "DeleteUser")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(int userId, CancellationToken cancellation)
    {
        await _userService.DeleteUser(userId, cancellation);
        return NoContent();
    }

    
}