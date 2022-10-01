using ElectronicBoard.Contracts.Filters.Report;
using ElectronicBoard.Domain.Report;

namespace ElectronicBoard.AppServices.Repositories.Report;

/// <summary>
/// Репозиторий для работы с жалобами на объявления <see cref="AdvtReportEntity"/>>
/// </summary>
public interface IAdvtReportRepository 
{
    /// <summary>
    /// Возвращает полный список жалоб.
    /// </summary>
    /// <returns>Коллекция жалоб <see cref="AdvtReportEntity"/>.</returns>
    public Task<IEnumerable<AdvtReportEntity>> GetAllAdvtReportEntities(AdvtReportFilterRequest? advtReportFilter);
    
    /// <summary>
    /// Возвращает жалобу по идентификатору.
    /// </summary>
    /// <param name="advtReportId">Идентификатор жалобы.</param>
    /// <returns>Жалоба <see cref="AdvtReportEntity"/>.</returns>
    public Task<AdvtReportEntity?> GetAdvtReportEntityById(int advtReportId);

    /// <summary>
    /// Добавляет жалобу.
    /// </summary>
    /// <param name="advtReportModel">Жалоба <see cref="AdvtReportEntity"/>.</param>
    /// <returns>Идентификатор жалобы <see cref="AdvtReportEntity"/>.</returns>
    public Task<int> AddAdvtReportEntity(AdvtReportEntity advtReportModel);

    /// <summary>
    /// Обновляет данные жалобы.
    /// </summary>
    /// <param name="advtReportModel">Жалоба <see cref="AdvtReportEntity"/>.</param>
    public Task UpdateAdvtReportEntity(AdvtReportEntity advtReportModel);

    /// <summary>
    /// Удаляет жалобу.
    /// </summary>
    /// <param name="advtReportId">Идентификатор жалобы <see cref="AdvtReportEntity"/>.</param>
    public Task DeleteAdvtReportEntity(int advtReportId);
}