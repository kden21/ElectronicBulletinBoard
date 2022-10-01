using System.Net;
using ElectronicBoard.AppServices.Services.Report.AdvtReport;
using ElectronicBoard.Contracts.Dto.Report;
using ElectronicBoard.Contracts.Filters.Report;
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
    public async Task<IActionResult> GetAdvtReports([FromQuery]AdvtReportFilterRequest advtReportFilter)
    {
        return Ok(await _advtReportService.GetAllAdvtReports(advtReportFilter));
    }
    
    /// <summary>
    /// Возвращает жалобу по Id.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <returns>Жалоба <see cref="AdvtReportDto"/>.</returns>
    [HttpGet("{advtReportId:int}", Name = "GetAdvtReportById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(AdvtReportDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAdvtReportById(int advtReportId)
    {
        return Ok(await _advtReportService.GetAdvtReportById(advtReportId));
    }

    /// <summary>
    /// Добавляет новую жалобу.
    /// </summary>
    /// <returns></returns>
    [HttpPost(Name = "CreateAdvtReport")]
    [ProducesResponseType(typeof(AdvtReportDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> CreateAdvtReport([FromBody] AdvtReportDto model)
    {
        model = await _advtReportService.CreateAdvtReport(model);
        return CreatedAtAction("GetAdvtReportById", new { advtReportId = model.Id }, model);
    }
    
    /// <summary>
    /// Обновляет данные жалобы.
    /// </summary>
    /// <param name="advtReportId">Идентификатор жалобы.</param>
    /// <param name="advtReportDto">Жалоба.</param>
    [HttpPut("{advtReportId:int}", Name = "UpdateAdvtReport")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateAdvtReport(int advtReportId, [FromBody]AdvtReportDto advtReportDto)
    {
        await _advtReportService.UpdateAdvtReport(advtReportId, advtReportDto);
        return Ok();
    }
    
    /// <summary>
    /// Удаляет жалобу.
    /// </summary>
    /// <param name="advtReportId">Идентификатор жалобы.</param>
    [HttpDelete("{advtReportId:int}", Name = "DeleteAdvtReport")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteAdvtReport(int advtReportId)
    {
        await _advtReportService.DeleteAdvtReport(advtReportId);
        return NoContent();
    }
}