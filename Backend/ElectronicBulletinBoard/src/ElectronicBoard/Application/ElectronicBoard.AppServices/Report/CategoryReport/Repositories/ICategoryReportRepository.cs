using ElectronicBoard.Contracts.Shared.Filters.Report;
using ElectronicBoard.Domain.Report;

namespace ElectronicBoard.AppServices.Report.CategoryReport.Repositories;

/// <summary>
/// Репозиторий для работы с категориями жалоб <see cref="CategoryReportEntity"/>>
/// </summary>
public interface ICategoryReportRepository
{
    /// <summary>
    /// Возвращает полную коллекцию категорий.
    /// </summary>
    /// <returns>Коллекция категориийи<see cref="CategoryReportEntity"/>.</returns>
    public Task<IEnumerable<CategoryReportEntity>> GetAllCategoryReportEntities(CancellationToken cancellation);
    
    /// <summary>
    /// Возвращает фильтрованную коллекцию категорий.
    /// </summary>
    /// <param name="сategoryReportFilter">Фильтр выборки.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Коллекция категорий.</returns>
    public Task<IEnumerable<CategoryReportEntity>> GetFilterCategoryReportEntities(CategoryReportFilterRequest? сategoryReportFilter, CancellationToken cancellation);

    /// <summary>
    /// Возвращает категорию по идентификатору.
    /// </summary>
    /// <param name="сategoryReportId">Идентификатор категории.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Категория <see cref="CategoryReportEntity"/>.</returns>
    public Task<CategoryReportEntity?> GetCategoryReportEntityById(int сategoryReportId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет категорию.
    /// </summary>
    /// <param name="сategoryReportModel">Категория <see cref="CategoryReportEntity"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Идентификатор категории <see cref="CategoryReportEntity"/>.</returns>
    public Task<int> AddCategoryReportEntity(CategoryReportEntity сategoryReportModel, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные категории.
    /// </summary>
    /// <param name="сategoryReportModel">Категория <see cref="CategoryReportEntity"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task UpdateCategoryReportEntity(CategoryReportEntity сategoryReportModel, CancellationToken cancellation);

    /// <summary>
    /// Удаляет категорию.
    /// </summary>
    /// <param name="сategoryReportId">Идентификатор категории <see cref="CategoryReportEntity"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task DeleteCategoryReportEntity(int сategoryReportId, CancellationToken cancellation);
}