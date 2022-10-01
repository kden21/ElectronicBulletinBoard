using ElectronicBoard.Contracts.Filters.Report;
using ElectronicBoard.Domain.Report;

namespace ElectronicBoard.AppServices.Repositories.Report;

/// <summary>
/// Репозиторий для работы с категориями жалоб <see cref="CategoryReportEntity"/>>
/// </summary>
public interface ICategoryReportRepository
{
    /// <summary>
    /// Возвращает полный список категорий.
    /// </summary>
    /// <returns>Коллекция категориийи<see cref="CategoryReportEntity"/>.</returns>
    public Task<IEnumerable<CategoryReportEntity>> GetAllCategoryReportEntities(CategoryReportFilterRequest? сategoryReportFilter);
    
    /// <summary>
    /// Возвращает категорию по идентификатору.
    /// </summary>
    /// <param name="сategoryReportId">Идентификатор категории.</param>
    /// <returns>Категория <see cref="CategoryReportEntity"/>.</returns>
    public Task<CategoryReportEntity?> GetCategoryReportEntityById(int сategoryReportId);

    /// <summary>
    /// Добавляет категорию.
    /// </summary>
    /// <param name="сategoryReportModel">Категория <see cref="CategoryReportEntity"/>.</param>
    /// <returns>Идентификатор категории <see cref="CategoryReportEntity"/>.</returns>
    public Task<int> AddCategoryReportEntity(CategoryReportEntity сtegorytReportModel);

    /// <summary>
    /// Обновляет данные категории.
    /// </summary>
    /// <param name="сategoryReportModel">Категория <see cref="CategoryReportEntity"/>.</param>
    public Task UpdateCategoryReportEntity(CategoryReportEntity сategoryReportModel);

    /// <summary>
    /// Удаляет категорию.
    /// </summary>
    /// <param name="сategoryReportId">Идентификатор категории <see cref="CategoryReportEntity"/>.</param>
    public Task DeleteCategoryReportEntity(int сategoryReportId);
}