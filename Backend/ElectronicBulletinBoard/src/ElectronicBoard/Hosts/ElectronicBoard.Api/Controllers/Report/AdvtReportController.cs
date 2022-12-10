using System.Net;
using ElectronicBoard.AppServices.Report.AdvtReport.Services;
using ElectronicBoard.Contracts.Report.AdvtReport.Dto;
using ElectronicBoard.Contracts.Shared.Filters.Report;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicBoard.Api.Controllers.Report;

/// <summary>
/// Работа с жалобами на объявления <see cref="AdvtReportDto"/>.
/// </summary>
[ApiController]
[Produces("application/json")]
[Route("v1/advtReports")]
public class AdvtReportController : ControllerBase
{
    private readonly ILogger<AdvtReportController> _logger;
    private readonly IAdvtReportService _advtReportService;

    public AdvtReportController(ILogger<AdvtReportController> logger, IAdvtReportService advtReportService)
    {
        _logger = logger;
        _advtReportService = advtReportService;
    }
    
    /// <summary>
    /// Возвращает коллекцию жалоб.
    /// </summary>
    /// <returns>Коллекция жалоб <see cref="AdvtReportDto"/>.</returns>
    [HttpGet(Name = "GetAdvtReports")]
    [ProducesResponseType(typeof(IReadOnlyCollection<AdvtReportDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllAdvtReports(CancellationToken cancellation)
    {
        return Ok(await _advtReportService.GetAllAdvtReports(cancellation));
    }
    
    /// <summary>
    /// Возвращает фильтрованную коллекцию жалоб.
    /// </summary>
    /// <returns>Коллекция жалоб <see cref="AdvtReportDto"/>.</returns>
    [HttpGet("advtReportFilter", Name = "GetFilterAdvtReports")]
    [ProducesResponseType(typeof(IReadOnlyCollection<AdvtReportDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetFilterAdvtReports([FromQuery]AdvtReportFilterRequest advtReportFilter, CancellationToken cancellation)
    {
        return Ok(await _advtReportService.GetFilterAdvtReports(advtReportFilter, cancellation));
    }
    
    /// <summary>
    /// Возвращает жалобу по Id.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <returns>Жалоба <see cref="AdvtReportDto"/>.</returns>
    [HttpGet("{advtReportId:int}", Name = "GetAdvtReportById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(AdvtReportDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAdvtReportById(int advtReportId, CancellationToken cancellation)
    {
        return Ok(await _advtReportService.GetAdvtReportById(advtReportId, cancellation));
    }

    /// <summary>
    /// Добавляет новую жалобу.
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [HttpPost(Name = "CreateAdvtReport")]
    [ProducesResponseType(typeof(AdvtReportDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> CreateAdvtReport([FromBody] AdvtReportDto model, CancellationToken cancellation)
    {
        model = await _advtReportService.CreateAdvtReport(model, cancellation);
        return CreatedAtAction("GetAdvtReportById", new { advtReportId = model.Id }, model);
    }
    
    /// <summary>
    /// Обновляет данные жалобы.
    /// </summary>
    /// <param name="advtReportId">Идентификатор жалобы.</param>
    /// <param name="advtReportDto">Жалоба.</param>
    [Authorize]
    [HttpPut("{advtReportId:int}", Name = "UpdateAdvtReport")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateAdvtReport(int advtReportId, [FromBody]AdvtReportDto advtReportDto, CancellationToken cancellation)
    {
        await _advtReportService.UpdateAdvtReport(advtReportId, advtReportDto, cancellation);
        return Ok();
    }
    
    /// <summary>
    /// Удаляет жалобу.
    /// </summary>
    /// <param name="advtReportId">Идентификатор жалобы.</param>
    [Authorize]
    [HttpDelete("{advtReportId:int}", Name = "DeleteAdvtReport")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteAdvtReport(int advtReportId, CancellationToken cancellation)
    {
        await _advtReportService.DeleteAdvtReport(advtReportId, cancellation);
        return NoContent();
    }
}