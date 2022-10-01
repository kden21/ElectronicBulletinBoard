using ElectronicBoard.Contracts.Dto.Report;
using ElectronicBoard.Contracts.Filters.Report;
using ElectronicBoard.Domain.Report;

namespace ElectronicBoard.AppServices.Services.Report.CategoryReport;

/// <summary>
/// Сервис для работы с категориями жалоб <see cref="CategoryReportEntity"/>.
/// </summary>
public interface ICategoryReportService
{
    /// <summary>
    /// Возвращает категорию по Id.
    /// </summary>
    /// <param name="сategoryReportId">Идентификатор категории.</param>
    /// <returns>Модель представления категории <see cref="CategoryReportDto"/>.</returns>
    public Task<CategoryReportDto> GetCategoryReportById(int сategoryReportId);

    /// <summary>
    /// Добавляет категорию.
    /// </summary>
    /// <param name="сategoryReportDto">Модель представления категории без Id <see cref="CategoryReportDto"/></param>
    /// <returns>Модель представления категории <see cref="CategoryReportDto"/></returns>
    public Task<CategoryReportDto> CreateCategoryReport(CategoryReportDto сategoryReportDto);

    /// <summary>
    /// Возвращает фильтрованную/полную коллекцию категорий.
    /// </summary>
    /// <param name="filterRequest">Параметр фильтрации.</param>
    /// <returns>Коллекция категорий <see cref="CategoryReportDto"/>.</returns>
    public Task<IEnumerable<CategoryReportDto>> GetAllCategoryReports(CategoryReportFilterRequest? filterRequest);

    /// <summary>
    /// Удаляет категорию.
    /// </summary>
    /// <param name="сategoryReportId">Идентификатор категории.</param>
    public Task DeleteCategoryReport(int сategoryReportId);

    /// <summary>
    /// Обновляет данные категории.
    /// </summary>
    /// <param name="сategoryReportId">Идентификатор категории.</param>
    /// <param name="сategoryReportDto">Обновленная модель представления категории.</param>
    public Task UpdateCategoryReport(int сategoryReportId, CategoryReportDto сategoryReportDto);
}