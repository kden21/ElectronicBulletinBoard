using System.Net;
using ElectronicBoard.AppServices.Category.Services;
using ElectronicBoard.Contracts.Category.Dto;
using ElectronicBoard.Contracts.Shared.Filters;
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
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    /// <summary>
    /// Возвращает фильтрованную коллекцию категорий.
    /// </summary>
    /// <returns>Коллекция категорий <see cref="CategoryDto"/>.</returns>
    [HttpGet("categoryFilter",Name = "GetFilterCategories")]
    [ProducesResponseType(typeof(IReadOnlyCollection<CategoryDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetFilterCategories([FromQuery]CategoryFilterRequest? categoryFilter, CancellationToken cancellation)
    {
        return Ok(await _categoryService.GetFilterCategories(categoryFilter, cancellation));
    }
    
    /// <summary>
    /// Возвращает коллекцию категорий.
    /// </summary>
    /// <returns>Коллекция категорий <see cref="CategoryDto"/>.</returns>
    [HttpGet(Name = "GetCategories")]
    [ProducesResponseType(typeof(IReadOnlyCollection<CategoryDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllCategories(CancellationToken cancellation)
    {
        return Ok(await _categoryService.GetAllCategories(cancellation));
    }

    /// <summary>
    /// Возвращает категорию по Id.
    /// </summary>
    /// <param name="categoryId">Идентификатор.</param>
    /// <param name="cancellation">Маркёр отмены.</param>
    /// <returns>Категория <see cref="CategoryDto"/>.</returns>
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
    /// <param name="cancellation">Маркёр отмены.</param>
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
    /// <param name="cancellation">Маркёр отмены.</param>
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