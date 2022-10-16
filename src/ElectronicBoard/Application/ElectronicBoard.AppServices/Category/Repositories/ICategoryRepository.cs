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
    /// <returns>Коллекция категория <see cref="CategoryEntity"/>.</returns>
    public Task<IEnumerable<CategoryEntity>> GetFilterCategoryEntities(CategoryFilterRequest? categoryFilter, CancellationToken cancellation);
    
    public Task<IEnumerable<CategoryEntity>> GetAllCategoryEntities(CancellationToken cancellation);
    
    /// <summary>
    /// Возвращает категорию по идентификатору.
    /// </summary>
    /// <param name="categoryId">Идентификатор категории.</param>
    /// <returns>Категория <see cref="CategoryEntity"/>.</returns>
    public Task<CategoryEntity?> GetCategoryEntityById(int categoryId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет категорию.
    /// </summary>
    /// <param name="categoryModel">Категория <see cref="CategoryEntity"/>.</param>
    /// <returns>Идентификатор категории <see cref="CategoryEntity"/>.</returns>
    public Task<int> AddCategoryEntity(CategoryEntity categoryModel, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные категории.
    /// </summary>
    /// <param name="categoryModel">Категория <see cref="CategoryEntity"/>.</param>
    public Task UpdateCategoryEntity(CategoryEntity categoryModel, CancellationToken cancellation);

    /// <summary>
    /// Удаляет категорию.
    /// </summary>
    /// <param name="categoryId">Идентификатор категории <see cref="CategoryEntity"/>.</param>
    public Task DeleteCategoryEntity(int categoryId, CancellationToken cancellation);
}