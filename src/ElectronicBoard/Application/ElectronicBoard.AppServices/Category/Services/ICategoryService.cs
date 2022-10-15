using ElectronicBoard.Contracts.Category.Dto;
using ElectronicBoard.Contracts.Shared.Filters;

namespace ElectronicBoard.AppServices.Category.Services;

/// <summary>
/// Сервис для работы с категориями <see cref="CategoryDto"/>.
/// </summary>
public interface ICategoryService
{
    /// <summary>
    /// Возвращает категорию по Id.
    /// </summary>
    /// <param name="categoryId">Идентификатор категории.</param>
    /// <returns>Модель представления категории <see cref="CategoryDto"/>.</returns>
    public Task<CategoryDto> GetCategoryById(int categoryId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет категорию.
    /// </summary>
    /// <param name="categoryDto">Модель представления категории без Id <see cref="CategoryDto"/></param>
    /// <returns>Модель представления категории <see cref="CategoryDto"/></returns>
    public Task<CategoryDto> CreateCategory(CategoryDto categoryDto, CancellationToken cancellation);

    /// <summary>
    /// Возвращает фильтрованную/полную коллекцию категорий.
    /// </summary>
    /// <param name="filterRequest">Параметр фильтрации.</param>
    /// <returns>Коллекция категорий <see cref="CategoryDto"/>.</returns>
    public Task<IEnumerable<CategoryDto>> GetAllCategories(CategoryFilterRequest? filterRequest, CancellationToken cancellation);

    /// <summary>
    /// Удаляет категорию.
    /// </summary>
    /// <param name="categoryId">Идентификатор категории.</param>
    public Task DeleteCategory(int categoryId, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные категории.
    /// </summary>
    /// <param name="categoryId">Идентификатор категории.</param>
    /// <param name="categoryDto">Обновленная модель представления категории.</param>
    public Task UpdateCategory(int categoryId, CategoryDto categoryDto, CancellationToken cancellation);
}