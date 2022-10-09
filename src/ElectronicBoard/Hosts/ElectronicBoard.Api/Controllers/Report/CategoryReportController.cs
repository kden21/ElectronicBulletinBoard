using System.Net;
using ElectronicBoard.AppServices.Services.Report.CategoryReport;
using ElectronicBoard.Contracts.Dto.Report;
using ElectronicBoard.Contracts.Filters.Report;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicBoard.Api.Controllers.Report;

/// <summary>
/// Работа с категориями жалоб <see cref="CategoryReportDto"/>.
/// </summary>
[ApiController]
[Produces("application/json")]
[Route("v1/categoryReports")]
public class CategoryReportController : ControllerBase
{
    private readonly ILogger<CategoryReportController> _logger;
    private readonly ICategoryReportService _categoryReportService;

    public CategoryReportController(ILogger<CategoryReportController> logger, ICategoryReportService categoryReportService)
    {
        _logger = logger;
        _categoryReportService = categoryReportService;
    }
    
    /// <summary>
    /// Возвращает коллекцию категорий.
    /// </summary>
    /// <returns>Коллекция категорий <see cref="CategoryReportDto"/>.</returns>
    [HttpGet(Name = "GetCategoryReports")]
    [ProducesResponseType(typeof(IReadOnlyCollection<CategoryReportDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCategoryReports([FromQuery]CategoryReportFilterRequest categoryReportFilter, CancellationToken cancellation)
    {
        return Ok(await _categoryReportService.GetAllCategoryReports(categoryReportFilter, cancellation));
    }
    
    /// <summary>
    /// Возвращает категорию по Id.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <returns>Категория <see cref="CategoryReportDto"/>.</returns>
    [HttpGet("{categoryReportId:int}", Name = "GetCategoryReportById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(CategoryReportDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCategoryReportById(int categoryReportId, CancellationToken cancellation)
    {
        return Ok(await _categoryReportService.GetCategoryReportById(categoryReportId, cancellation));
    }

    /// <summary>
    /// Добавляет новую категорию.
    /// </summary>
    /// <returns></returns>
    [HttpPost(Name = "CreateCategoryReport")]
    [ProducesResponseType(typeof(CategoryReportDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> CreateCategoryReport([FromBody] CategoryReportDto model, CancellationToken cancellation)
    {
        model = await _categoryReportService.CreateCategoryReport(model, cancellation);
        return CreatedAtAction("GetCategoryReportById", new { categoryReportId = model.Id }, model);
    }
    
    /// <summary>
    /// Обновляет данные категории.
    /// </summary>
    /// <param name="categoryReportId">Идентификатор категории.</param>
    /// <param name="categoryReportDto">Категория.</param>
    [HttpPut("{categoryReportId:int}", Name = "UpdateCategoryReport")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateCategoryReport(int categoryReportId, [FromBody]CategoryReportDto categoryReportDto, CancellationToken cancellation)
    {
        await _categoryReportService.UpdateCategoryReport(categoryReportId, categoryReportDto, cancellation);
        return Ok();
    }
    
    /// <summary>
    /// Удаляет категорию.
    /// </summary>
    /// <param name="categoryReportId">Идентификатор категории.</param>
    [HttpDelete("{categoryReportId:int}", Name = "DeleteCategoryReport")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteCategoryReport(int categoryReportId, CancellationToken cancellation)
    {
        await _categoryReportService.DeleteCategoryReport(categoryReportId, cancellation);
        return NoContent();
    }
}