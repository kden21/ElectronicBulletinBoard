using System.Net;
using ElectronicBoard.AppServices.Services.User;
using ElectronicBoard.Contracts;
using ElectronicBoard.Contracts.Dto;
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
    [HttpGet(Name = "GetUsers")]
    [ProducesResponseType(typeof(IReadOnlyCollection<UserDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(_userService.GetAllUsers());
    }
    
    /// <summary>
    /// Возвращает пользователя по Id.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <returns>Пользователь <see cref="UserDto"/>.</returns>
    [HttpGet("{userId:int}", Name = "GetUserById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById(int userId)
    {
        return Ok(await _userService.GetUserById(userId));
    }

    /// <summary>
    /// Добавляет нового пользователя.
    /// </summary>
    /// <returns></returns>
    [HttpPost(Name = "CreateUser")]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> Create([FromBody] UserDto model)
    {
        model = await _userService.CreateUser(model);
        return CreatedAtAction("GetById", new { userId = model.Id }, model);
    }
    
    /// <summary>
    /// Обновляет данные пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="userDto">Пользователь.</param>
    [HttpPut("{userId:int}", Name = "UpdateUser")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Update(int userId, [FromBody]UserDto userDto)
    {
        await _userService.UpdateUser(userId, userDto);
        return Ok();
    }
    
    /// <summary>
    /// Удаляет пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    [HttpDelete("{userId:int}", Name = "DeleteUser")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(int userId)
    {
        await _userService.DeleteUser(userId);
        return NoContent();
    }
}