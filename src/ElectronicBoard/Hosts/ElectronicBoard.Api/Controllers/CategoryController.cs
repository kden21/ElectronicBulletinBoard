using System.Net;
using ElectronicBoard.AppServices.Services.Category;
using ElectronicBoard.Contracts.Dto;
using ElectronicBoard.Contracts.Filters;
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
    [HttpGet(Name = "GetCategories")]
    [ProducesResponseType(typeof(IReadOnlyCollection<CategoryDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAsync([FromQuery]CategoryFilterRequest categoryFilter)
    {
        return Ok(await _categoryService.GetAllCategories(categoryFilter));
    }
    
    /// <summary>
    /// Возвращает категорию по Id.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <returns>Категория <see cref="CategoryDto"/>.</returns>
    [HttpGet("{categoryId:int}", Name = "GetCategoryById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(CategoryDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCategoryById(int categoryId)
    {
        return Ok(await _categoryService.GetCategoryById(categoryId));
    }

    /// <summary>
    /// Добавляет новую категорию.
    /// </summary>
    /// <returns></returns>
    [HttpPost(Name = "CreateCategory")]
    [ProducesResponseType(typeof(CategoryDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryDto model)
    {
        model = await _categoryService.CreateCategory(model);
        return CreatedAtAction("GetCategoryById", new { categoryId = model.Id }, model);
    }
    
    /// <summary>
    /// Обновляет данные категории.
    /// </summary>
    /// <param name="categoryId">Идентификатор категории.</param>
    /// <param name="categoryDto">Категория.</param>
    [HttpPut("{categoryId:int}", Name = "UpdateCategory")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateCategory(int categoryId, CategoryDto categoryDto)
    {
        await _categoryService.UpdateCategory(categoryId, categoryDto);
        return Ok();
    }
    
    /// <summary>
    /// Удаляет категорию.
    /// </summary>
    /// <param name="categoryId">Идентификатор категории.</param>
    [HttpDelete("{categoryId:int}", Name = "DeleteCategory")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteCategory(int categoryId)
    {
        await _categoryService.DeleteCategory(categoryId);
        return NoContent();
    }
}