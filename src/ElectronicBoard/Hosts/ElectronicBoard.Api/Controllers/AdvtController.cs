using System.Net;
using ElectronicBoard.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicBoard.Api.Controllers;

/// <summary>
/// Работа с объявлением.
/// </summary>
[ApiController]
[Route("v1/[controller]")]
public class AdvtController : ControllerBase
{
    private readonly ILogger<AdvtController> _logger;

    public AdvtController(ILogger<AdvtController> logger)
    {
        _logger = logger;
    }
    
    /// <summary>
    /// Возвращает коллекцию объявлений.
    /// </summary>
    /// <returns>Коллекция элементов <see cref="AdvtDto"/>.</returns>
    [HttpGet(Name = "GetAdvts")]
    [ProducesResponseType(typeof(IReadOnlyCollection<AdvtDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAsync()
    {
        return await Task.FromResult(Ok());
    }
    
    /// <summary>
    /// Возвращает объявление по Id.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <returns>Объявление <see cref="AdvtDto"/>.</returns>
    [HttpGet("{id}", Name = "GetAdvtById")]
    [ProducesResponseType(typeof(AdvtDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById()
    {
        return await Task.FromResult(Ok());
    }

    /// <summary>
    /// Добавляет новое объявление.
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create()
    {
        return await Task.FromResult(Ok());
    }
    
    /// <summary>
    /// Обновляет данные объявления.
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateAsync()
    {
        return await Task.FromResult(Ok());
    }
    
    /// <summary>
    /// Удаляет объявление.
    /// </summary>
    /// <param name="Id">Идентификатор объявления.</param>
    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return await Task.FromResult(Ok());
    }
}