using ElectronicBoard.Contracts.Report.CategoryReport.Dto;
using ElectronicBoard.Contracts.Shared.Filters.Report;
using ElectronicBoard.Domain.Report;

namespace ElectronicBoard.AppServices.Report.CategoryReport.Services;

/// <summary>
/// Сервис для работы с категориями жалоб <see cref="CategoryReportEntity"/>.
/// </summary>
public interface ICategoryReportService
{
    /// <summary>
    /// Возвращает категорию по Id.
    /// </summary>
    /// <param name="сategoryReportId">Идентификатор категории.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Модель представления категории <see cref="CategoryReportDto"/>.</returns>
    public Task<CategoryReportDto> GetCategoryReportById(int сategoryReportId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет категорию.
    /// </summary>
    /// <param name="сategoryReportDto">Модель представления категории без Id <see cref="CategoryReportDto"/></param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Модель представления категории <see cref="CategoryReportDto"/></returns>
    public Task<CategoryReportDto> CreateCategoryReport(CategoryReportDto сategoryReportDto, CancellationToken cancellation);

    /// <summary>
    /// Возвращает фильтрованную коллекцию категорий.
    /// </summary>
    /// <param name="filterRequest">Параметр фильтрации.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Коллекция категорий <see cref="CategoryReportDto"/>.</returns>
    public Task<IEnumerable<CategoryReportDto>> GetFilterCategoryReports(CategoryReportFilterRequest? filterRequest, CancellationToken cancellation);
   
    /// <summary>
    /// Возвращает полную коллекцию категорий.
    /// </summary>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Коллекция категорий <see cref="CategoryReportDto"/>.</returns>
    public Task<IEnumerable<CategoryReportDto>> GetAllCategoryReports(CancellationToken cancellation);

    /// <summary>
    /// Удаляет категорию.
    /// </summary>
    /// <param name="сategoryReportId">Идентификатор категории.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task DeleteCategoryReport(int сategoryReportId, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные категории.
    /// </summary>
    /// <param name="сategoryReportId">Идентификатор категории.</param>
    /// <param name="сategoryReportDto">Обновленная модель представления категории.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task UpdateCategoryReport(int сategoryReportId, CategoryReportDto сategoryReportDto, CancellationToken cancellation);
}