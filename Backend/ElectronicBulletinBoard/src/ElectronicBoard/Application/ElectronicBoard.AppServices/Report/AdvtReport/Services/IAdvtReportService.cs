using ElectronicBoard.Contracts.Report.AdvtReport.Dto;
using ElectronicBoard.Contracts.Shared.Filters.Report;
using ElectronicBoard.Domain.Report;

namespace ElectronicBoard.AppServices.Report.AdvtReport.Services;

/// <summary>
/// Сервис для работы с жалобами на объявления <see cref="AdvtReportEntity"/>.
/// </summary>
public interface IAdvtReportService
{
    /// <summary>
    /// Возвращает жалобу по Id.
    /// </summary>
    /// <param name="advtReportId">Идентификатор жалобы.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Модель представления жалобы <see cref="AdvtReportDto"/>.</returns>
    public Task<AdvtReportDto> GetAdvtReportById(int advtReportId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет жалобу.
    /// </summary>
    /// <param name="advtReportDto">Модель представления жалобы без Id <see cref="AdvtReportDto"/></param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Модель представления жалобы <see cref="AdvtReportDto"/></returns>
    public Task<AdvtReportDto> CreateAdvtReport(AdvtReportDto advtReportDto, CancellationToken cancellation);

    /// <summary>
    /// Возвращает полную коллекцию жалоб.
    /// </summary>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Коллекция жалоб <see cref="AdvtReportDto"/>.</returns>
    public Task<IEnumerable<AdvtReportDto>> GetAllAdvtReports(CancellationToken cancellation);
    
    /// <summary>
    /// Возвращает фильтрованную коллекцию жалоб.
    /// </summary>
    /// <param name="filterRequest">Параметр фильтрации.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns></returns>
    public Task<IEnumerable<AdvtReportDto>> GetFilterAdvtReports(AdvtReportFilterRequest? filterRequest, CancellationToken cancellation);

    /// <summary>
    /// Удаляет жалобу.
    /// </summary>
    /// <param name="advtReportId">Идентификатор жалобы.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task DeleteAdvtReport(int advtReportId, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные жалобы.
    /// </summary>
    /// <param name="advtReportId">Идентификатор жалобы.</param>
    /// <param name="advtReportDto">Обновленная модель представления жалобы.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task UpdateAdvtReport(int advtReportId, AdvtReportDto advtReportDto, CancellationToken cancellation);
}