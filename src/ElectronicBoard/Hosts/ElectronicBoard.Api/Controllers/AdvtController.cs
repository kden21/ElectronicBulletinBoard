using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using ElectronicBoard.AppServices.Services.Advt;
using ElectronicBoard.Contracts.Advt.Dto;
using ElectronicBoard.Contracts.Shared.Enums;
using ElectronicBoard.Contracts.Shared.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

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
    public async Task<IActionResult> GetByIdAsync(int advtId, CancellationToken cancellation)
    {
        //TODO:проверка на пользователя
        var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
        var handler = new JwtSecurityTokenHandler();
        var tokenS = handler.ReadToken(_bearer_token) as JwtSecurityToken;
        var id = tokenS.Claims.First(claim => claim.Type == ClaimTypes.Role).Value;

        return Ok(await _advtService.GetAdvtById(advtId, cancellation));
    }

    /// <summary>
    /// Добавляет новое объявление.
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpPost(Name = "CreateAdvt")]
    [ProducesResponseType(typeof(AdvtDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    [Authorize]
    public async Task<IActionResult> CreateAsync([FromBody] AdvtDto model, CancellationToken cancellation)
    {
        model = await _advtService.CreateAdvt(model, cancellation);
        return CreatedAtAction("GetById", new { advtId = model.Id }, model);
    }
    
    /// <summary>
    /// Обновляет данные объявления.
    /// </summary>
    /// <param name="advtId">Идентификатор объявления.</param>
    /// <param name="advtDto">Объявление.</param>
    [Authorize]
    [HttpPut("{advtId:int}", Name = "UpdateAdvt")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateAsync(int advtId, [FromBody]AdvtDto advtDto, CancellationToken cancellation)
    {
        await _advtService.UpdateAdvt(advtId, advtDto, cancellation);
        return Ok();
    }
    
    /*/// <summary>
    /// Удаляет объявление.
    /// </summary>
    /// <param name="Id">Идентификатор объявления.</param>
    [Authorize]
    [HttpDelete("{advtId:int}", Name = "DeleteAdvt")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteAsync(int advtId, CancellationToken cancellation)
    {
        await _advtService.DeleteAdvt(advtId, cancellation);
        return NoContent();
    }*/
    
    /// <summary>
    /// Изменяет статус объявления на удаленное.
    /// </summary>
    /// <param name="Id">Идентификатор объявления.</param>
    [Authorize]
    [HttpDelete("{advtId:int}", Name = "DeleteAdvt")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> SoftDeleteAsync(int advtId, CancellationToken cancellation)
    {
        await _advtService.SoftDeleteAdvt(advtId, cancellation);
        return NoContent();
    }

   

    /// <summary>
    /// Возвращает фильтрованную коллекцию объявлений.
    /// </summary>
    /// <param name="advtFilter">Параметр фильтрации.</param>
    /// <returns>Коллекция элементов <see cref="AdvtDto"/>.</returns>
    [HttpGet("advtFilter", Name = "GetAdvtsFilter")]
    [ProducesResponseType(typeof(IReadOnlyCollection<AdvtDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetFilterAdvts([FromQuery]AdvtFilterRequest advtFilter, CancellationToken cancellation)
    {
        return Ok(await _advtService.GetFilterAdvts(advtFilter, cancellation));
    }
    
    /// <summary>
    /// Возвращает полную коллекцию объявлений.
    /// </summary>
    /// <param name="advtFilter">Параметр фильтрации.</param>
    /// <returns>Коллекция элементов <see cref="AdvtDto"/>.</returns>
    [HttpGet(Name = "GetAdvts")]
    [ProducesResponseType(typeof(IReadOnlyCollection<AdvtDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllAdvts(CancellationToken cancellation)
    {
        return Ok(await _advtService.GetAllAdvts(cancellation));
    }
    
    /// <summary>
    /// Добавляет/удаляет объявление в список/из списка избранных объявлений пользователя.
    /// </summary>
    /// <param name="advtId">Идентификатор объявления.</param>
    /// <param name="advtDto">Объявление.</param>
    [Authorize]
    [HttpPut("{advtId:int}/{userId:int}", Name = "UpdateFavoriteAdvt")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateAsync(int advtId, int userId, [FromQuery]StatusAction status,CancellationToken cancellation)
    {
        await _advtService.AdvtInFavorite(advtId, userId, status, cancellation);
        return Ok();
    }
}