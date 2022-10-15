using System.Net;
using ElectronicBoard.AppServices.Services.Report;
using ElectronicBoard.AppServices.Services.Report.UserReport;
using ElectronicBoard.Contracts.Dto.Report;
using ElectronicBoard.Contracts.Filters.Report;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicBoard.Api.Controllers.Report;

/// <summary>
/// Работа с жалобами на пользователей<see cref="UserReportDto"/>.
/// </summary>
[ApiController]
[Produces("application/json")]
[Route("v1/userReports")]
public class UserReportController : ControllerBase
{
    private readonly ILogger<UserReportController> _logger;
    private readonly IUserReportService _userReportService;

    public UserReportController(ILogger<UserReportController> logger, IUserReportService userReportService)
    {
        _logger = logger;
        _userReportService = userReportService;
    }
    
    /// <summary>
    /// Возвращает коллекцию жалоб.
    /// </summary>
    /// <returns>Коллекция жалоб <see cref="UserReportDto"/>.</returns>
    [HttpGet(Name = "GetUserReports")]
    [ProducesResponseType(typeof(IReadOnlyCollection<UserReportDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetUserReports([FromQuery]UserReportFilterRequest userReportFilter, CancellationToken cancellation)
    {
        return Ok(await _userReportService.GetAllUserReports(userReportFilter, cancellation));
    }
    
    /// <summary>
    /// Возвращает жалобу по Id.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <returns>Жалоба <see cref="UserReportDto"/>.</returns>
    [HttpGet("{userReportId:int}", Name = "GetUserReportById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(UserReportDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetUserReportById(int userReportId, CancellationToken cancellation)
    {
        return Ok(await _userReportService.GetUserReportById(userReportId, cancellation));
    }

    /// <summary>
    /// Добавляет новую жалобу.
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [HttpPost(Name = "CreateUserReport")]
    [ProducesResponseType(typeof(UserReportDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> CreateUserReport([FromBody] UserReportDto model, CancellationToken cancellation)
    {
        model = await _userReportService.CreateUserReport(model, cancellation);
        return CreatedAtAction("GetUserReportById", new { userReportId = model.Id }, model);
    }
    
    /// <summary>
    /// Обновляет данные жалобы.
    /// </summary>
    /// <param name="userReportId">Идентификатор жалобы.</param>
    /// <param name="userReportDto">Жалоба.</param>
    [Authorize]
    [HttpPut("{userReportId:int}", Name = "UpdateUserReport")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateUserReport(int userReportId, [FromBody]UserReportDto userReportDto, CancellationToken cancellation)
    {
        await _userReportService.UpdateUserReport(userReportId, userReportDto, cancellation);
        return Ok();
    }
    
    /// <summary>
    /// Удаляет жалобу.
    /// </summary>
    /// <param name="userReportId">Идентификатор жалобы.</param>
    [Authorize]
    [HttpDelete("{userReportId:int}", Name = "DeleteUserReport")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteUserReport(int userReportId, CancellationToken cancellation)
    {
        await _userReportService.DeleteUserReport(userReportId, cancellation);
        return NoContent();
    }
}