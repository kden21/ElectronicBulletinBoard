using ElectronicBoard.Contracts.Shared.Filters;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Category.Repositories;

/// <summary>
/// Репозиторий для работы с категориями <see cref="CategoryEntity"/>>
/// </summary>
public interface ICategoryRepository
{
    /// <summary>
    /// Возвращает полный список категорий.
    /// </summary>
    /// <returns>Коллекция категорий <see cref="CategoryEntity"/>.</returns>
    public Task<IEnumerable<CategoryEntity>> GetFilterCategoryEntities(CategoryFilterRequest? categoryFilter, CancellationToken cancellation);
    
    /// <summary>
    /// Возвращает полный список категорий.
    /// </summary>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns></returns>
    public Task<IEnumerable<CategoryEntity>> GetAllCategoryEntities(CancellationToken cancellation);

    /// <summary>
    /// Возвращает категорию по идентификатору.
    /// </summary>
    /// <param name="categoryId">Идентификатор категории.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Категория <see cref="CategoryEntity"/>.</returns>
    public Task<CategoryEntity?> GetCategoryEntityById(int categoryId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет категорию.
    /// </summary>
    /// <param name="categoryModel">Категория <see cref="CategoryEntity"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Идентификатор категории <see cref="CategoryEntity"/>.</returns>
    public Task<int> AddCategoryEntity(CategoryEntity categoryModel, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные категории.
    /// </summary>
    /// <param name="categoryModel">Категория <see cref="CategoryEntity"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task UpdateCategoryEntity(CategoryEntity categoryModel, CancellationToken cancellation);

    /// <summary>
    /// Удаляет категорию.
    /// </summary>
    /// <param name="categoryId">Идентификатор категории <see cref="CategoryEntity"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task DeleteCategoryEntity(int categoryId, CancellationToken cancellation);
}