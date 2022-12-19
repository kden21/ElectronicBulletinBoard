using System.Net;
using ElectronicBoard.AppServices.User.Services;
using ElectronicBoard.Contracts.Shared.Filters;
using ElectronicBoard.Contracts.User.Dto;
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
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    /// <summary>
    /// Возвращает фильтрованную коллекцию пользователей.
    /// </summary>
    /// <returns>Коллекция пользователей <see cref="UserDto"/>.</returns>
    [HttpGet("userFilter",Name = "GetFilterUsers")]
    [ProducesResponseType(typeof(IReadOnlyCollection<UserDto>), (int)HttpStatusCode.OK)]
    [Authorize (Roles="Admin")]
    public async Task<IActionResult> GetFilterUsers([FromQuery]UserFilterRequest userFilter, CancellationToken cancellation)
    {
        return Ok(await _userService.GetFilterUsers(userFilter, cancellation));
    }
    
    /// <summary>
    /// Возвращает коллекцию пользователей.
    /// </summary>
    /// <returns>Коллекция пользователей <see cref="UserDto"/>.</returns>
    [HttpGet(Name = "GetUsers")]
    [ProducesResponseType(typeof(IReadOnlyCollection<UserDto>), (int)HttpStatusCode.OK)]
    [Authorize (Roles="Admin")]
    public async Task<IActionResult> GetAllUsers(CancellationToken cancellation)
    {
        return Ok(await _userService.GetAllUsers(cancellation));
    }

    /// <summary>
    /// Возвращает пользователя по Id.
    /// </summary>
    /// <param name="userId">Идентификатор.</param>
    /// <param name="cancellation">Маркёр отмены.</param>
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
    /// <param name="cancellation">Маркёр отмены.</param>
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
    /// Изменяет статус пользователя на неактивный профиль.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellation">Маркёр отмены.</param>
    [Authorize]
    [HttpDelete("{userId:int}", Name = "DeleteUser")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(int userId, CancellationToken cancellation)
    {
        await _userService.SoftDeleteUser(userId, cancellation);
        return NoContent();
    }
}