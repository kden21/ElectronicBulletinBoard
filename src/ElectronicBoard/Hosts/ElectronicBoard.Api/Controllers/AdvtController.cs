using System.Net;
using ElectronicBoard.AppServices.Services.Advt;
using ElectronicBoard.Contracts.Dto;
using ElectronicBoard.Contracts.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicBoard.Api.Controllers;

/// <summary>
/// Работа с объявлением <see cref="AdvtDto"/>.
/// </summary>
[ApiController]
[Produces("application/json")]
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
    /// Возвращает объявление по Id.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <returns>Объявление <see cref="AdvtDto"/>.</returns>
    [HttpGet("{advtId:int}", Name = "GetAdvtById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(AdvtDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByIdAsync(int advtId)
    {
        return Ok(await _advtService.GetAdvtById(advtId));
    }

    /// <summary>
    /// Добавляет новое объявление.
    /// </summary>
    /// <returns>Идентификатор объявления.</returns>
    [HttpPost(Name = "CreateAdvt")]
    [ProducesResponseType(typeof(AdvtDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> CreateAsync([FromBody] AdvtDto model)
    {
        model = await _advtService.CreateAdvt(model);
        return CreatedAtAction("GetById", new { advtId = model.Id }, model);
    }
    
    /// <summary>
    /// Обновляет данные объявления.
    /// </summary>
    /// <param name="advtId">Идентификатор объявления.</param>
    /// <param name="advtDto">Объявление.</param>
    [HttpPut("{advtId:int}", Name = "UpdateAdvt")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateAsync(int advtId, AdvtDto advtDto)
    {
        await _advtService.UpdateAdvt(advtId, advtDto);
        return Ok();
    }
    
    /// <summary>
    /// Удаляет объявление.
    /// </summary>
    /// <param name="Id">Идентификатор объявления.</param>
    [HttpDelete("{advtId:int}", Name = "DeleteAdvt")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteAsync(int advtId)
    {
        await _advtService.DeleteAdvt(advtId);
        return NoContent();
    }

    
    /// <summary>
    /// Возвращает фильтрованную коллекцию объявлений.
    /// </summary>
    /// <param name="advtFilter">Параметр фильтрации.</param>
    /// <returns>Коллекция элементов <see cref="AdvtDto"/>.</returns>
    [HttpGet("{advtFilter}", Name = "GetAdvtsFilter")]
    [ProducesResponseType(typeof(IReadOnlyCollection<AdvtDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAdvts([FromQuery] AdvtFilterRequest advtFilter)
    {
        return Ok(_advtService.GetAll(advtFilter));
    }
}