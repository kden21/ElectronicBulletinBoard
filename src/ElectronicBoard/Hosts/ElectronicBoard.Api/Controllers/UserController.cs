using System.Net;
using ElectronicBoard.Contracts;
using ElectronicBoard.Contracts.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicBoard.Api.Controllers;

/// <summary>
/// Работа с пользователем.
/// </summary>
[ApiController]
[Route("v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }
    
    /// <summary>
    /// Возвращает коллекцию пользователей.
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "GetUsers")]
    [ProducesResponseType(typeof(IReadOnlyCollection<UserDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAsync()
    {
        return await Task.FromResult(Ok());
    }
    
    /// <summary>
    /// Возвращает пользователя по Id.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <returns>Пользователь <see cref="AdvtDto"/>.</returns>
    [HttpGet("{userId:int}", Name = "GetUserById")]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByIdAsync(int userId)
    {
        return await Task.FromResult(Ok());
    }

    /// <summary>
    /// Добавляет нового пользователя.
    /// </summary>
    /// <returns></returns>
    [HttpPost(Name = "CreateUser")]
    public async Task<IActionResult> CreateAsync()
    {
        return await Task.FromResult(Ok());
    }
    
    /// <summary>
    /// Обновляет данные пользователя.
    /// </summary>
    [HttpPut("{userId:int}", Name = "UpdateUser")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateAsync(int userId)
    {
        return await Task.FromResult(Ok());
    }
    
    /// <summary>
    /// Удаляет пользователя.
    /// </summary>
    /// <param name="Id">Идентификатор пользователя.</param>
    [HttpDelete("{userId:int}", Name = "DeleteUser")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteAsync(int userId)
    {
        return await Task.FromResult(Ok());
    }
}