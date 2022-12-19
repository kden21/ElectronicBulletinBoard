using ElectronicBoard.Contracts.Shared.Filters.Report;
using ElectronicBoard.Domain.Report;

namespace ElectronicBoard.AppServices.Report.AdvtReport.Repositories;

/// <summary>
/// Репозиторий для работы с жалобами на объявления <see cref="AdvtReportEntity"/>>
/// </summary>
public interface IAdvtReportRepository 
{
    /// <summary>
    /// Возвращает полную коллекцию жалоб на объявления.
    /// </summary>
    /// <returns>Коллекция жалоб <see cref="AdvtReportEntity"/>.</returns>
    public Task<IEnumerable<AdvtReportEntity>> GetFilterAdvtReportEntities(AdvtReportFilterRequest? advtReportFilter, CancellationToken cancellation);
   
    /// <summary>
    /// Возвращает фильтрованную коллекцию жалоб на объявления.
    /// </summary>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public Task<IEnumerable<AdvtReportEntity>> GetAllAdvtReportEntities(CancellationToken cancellation);

    /// <summary>
    /// Возвращает жалобу по идентификатору.
    /// </summary>
    /// <param name="advtReportId">Идентификатор жалобы.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Жалоба <see cref="AdvtReportEntity"/>.</returns>
    public Task<AdvtReportEntity?> GetAdvtReportEntityById(int advtReportId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет жалобу.
    /// </summary>
    /// <param name="advtReportModel">Жалоба <see cref="AdvtReportEntity"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Идентификатор жалобы <see cref="AdvtReportEntity"/>.</returns>
    public Task<int> AddAdvtReportEntity(AdvtReportEntity advtReportModel, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные жалобы.
    /// </summary>
    /// <param name="advtReportModel">Жалоба <see cref="AdvtReportEntity"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task UpdateAdvtReportEntity(AdvtReportEntity advtReportModel, CancellationToken cancellation);

    /// <summary>
    /// Удаляет жалобу.
    /// </summary>
    /// <param name="advtReportId">Идентификатор жалобы <see cref="AdvtReportEntity"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task DeleteAdvtReportEntity(int advtReportId, CancellationToken cancellation);
}