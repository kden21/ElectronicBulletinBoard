using System.Net;
using ElectronicBoard.AppServices.Services.Category;
using ElectronicBoard.Contracts.Dto;
using ElectronicBoard.Contracts.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicBoard.Api.Controllers;

/// <summary>
/// Работа с объявлением <see cref="CategoryDto"/>.
/// </summary>
[ApiController]
[Produces("application/json")]
[Route("v1/categories")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ICategoryService _categoryService;

    public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
    {
        _logger = logger;
        _categoryService = categoryService;
    }
    
    /// <summary>
    /// Возвращает коллекцию категорий.
    /// </summary>
    /// <returns>Коллекция категорий <see cref="CategoryDto"/>.</returns>
    [Authorize]
    [HttpGet(Name = "GetCategories")]
    [ProducesResponseType(typeof(IReadOnlyCollection<CategoryDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll([FromQuery]CategoryFilterRequest categoryFilter, CancellationToken cancellation)
    {
        return Ok(await _categoryService.GetAllCategories(categoryFilter, cancellation));
    }
    
    /// <summary>
    /// Возвращает категорию по Id.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <returns>Категория <see cref="CategoryDto"/>.</returns>
    [Authorize]
    [HttpGet("{categoryId:int}", Name = "GetCategoryById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(CategoryDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCategoryById(int categoryId, CancellationToken cancellation)
    {
        return Ok(await _categoryService.GetCategoryById(categoryId, cancellation));
    }

    /// <summary>
    /// Добавляет новую категорию.
    /// </summary>
    /// <returns></returns>
    [Authorize(Roles="Admin")]
    [HttpPost(Name = "CreateCategory")]
    [ProducesResponseType(typeof(CategoryDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryDto model, CancellationToken cancellation)
    {
        model = await _categoryService.CreateCategory(model, cancellation);
        return CreatedAtAction("GetCategoryById", new { categoryId = model.Id }, model);
    }
    
    /// <summary>
    /// Обновляет данные категории.
    /// </summary>
    /// <param name="categoryId">Идентификатор категории.</param>
    /// <param name="categoryDto">Категория.</param>
    [Authorize(Roles="Admin")]
    [HttpPut("{categoryId:int}", Name = "UpdateCategory")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody]CategoryDto categoryDto, CancellationToken cancellation)
    {
        await _categoryService.UpdateCategory(categoryId, categoryDto, cancellation);
        return Ok();
    }
    
    /// <summary>
    /// Удаляет категорию.
    /// </summary>
    /// <param name="categoryId">Идентификатор категории.</param>
    [Authorize(Roles="Admin")]
    [HttpDelete("{categoryId:int}", Name = "DeleteCategory")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteCategory(int categoryId, CancellationToken cancellation)
    {
        await _categoryService.DeleteCategory(categoryId, cancellation);
        return NoContent();
    }
}