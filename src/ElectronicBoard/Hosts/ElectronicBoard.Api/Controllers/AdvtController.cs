using System.Net;
using ElectronicBoard.AppServices.Advt.Services;
using ElectronicBoard.Contracts;
using ElectronicBoard.Contracts.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicBoard.Api.Controllers;

/// <summary>
/// Работа с объявлением.
/// </summary>
[ApiController]
[Route("v1/advts")]
public class AdvtController : ControllerBase
{
    private readonly ILogger<AdvtController> _logger;
    private readonly IAdvtService _advtService;
    
    public AdvtController(ILogger<AdvtController> logger, IAdvtService advtService)
    {
        _logger = logger;
        _advtService = advtService;
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
    [HttpGet("{advtId:int}", Name = "GetAdvtById")]
    [ProducesResponseType(typeof(AdvtDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByIdAsync(int advtId)
    {
        return Ok(await _advtService.GetById(advtId));
    }

    /// <summary>
    /// Добавляет новое объявление.
    /// </summary>
    /// <returns></returns>
    [HttpPost(Name = "CreateAdvt")]
    public async Task<IActionResult> CreateAsync()
    {
        return await Task.FromResult(Ok());
    }
    
    /// <summary>
    /// Обновляет данные объявления.
    /// </summary>
    [HttpPut("{advtId:int}", Name = "UpdateAdvt")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateAsync(int advtId)
    {
        return await Task.FromResult(Ok());
    }
    
    /// <summary>
    /// Удаляет объявление.
    /// </summary>
    /// <param name="Id">Идентификатор объявления.</param>
    [HttpDelete("{advtId:int}", Name = "DeleteAdvt")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteAsync(int advtId)
    {
        return await Task.FromResult(Ok());
    }
}