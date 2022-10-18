using ElectronicBoard.Contracts.Report.UserReport.Dto;
using ElectronicBoard.Contracts.Shared.Filters.Report;
using ElectronicBoard.Domain.Report;

namespace ElectronicBoard.AppServices.Report.UserReport.Services;

/// <summary>
/// Сервис для работы с жалобами на пользователей <see cref="UserReportEntity"/>.
/// </summary>
public interface IUserReportService
{
    /// <summary>
    /// Возвращает жалобу по Id.
    /// </summary>
    /// <param name="userReportId">Идентификатор жалобы.</param>
    /// <returns>Модель представления жалобы <see cref="UserReportDto"/>.</returns>
    public Task<UserReportDto> GetUserReportById(int userReportId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет жалобу.
    /// </summary>
    /// <param name="userReportDto">Модель представления жалобы без Id <see cref="UserReportDto"/></param>
    /// <returns>Модель представления жалобы <see cref="UserReportDto"/></returns>
    public Task<UserReportDto> CreateUserReport(UserReportDto userReportDto, CancellationToken cancellation);

    /// <summary>
    /// Возвращает фильтрованную/полную коллекцию жалоб.
    /// </summary>
    /// <param name="filterRequest">Параметр фильтрации.</param>
    /// <returns>Коллекция жалоб <see cref="UserReportDto"/>.</returns>
    public Task<IEnumerable<UserReportDto>> GetFilterUserReports(UserReportFilterRequest? filterRequest, CancellationToken cancellation);
    public Task<IEnumerable<UserReportDto>> GetAllUserReports(CancellationToken cancellation);

    /// <summary>
    /// Удаляет жалобу.
    /// </summary>
    /// <param name="userReportId">Идентификатор жалобы.</param>
    public Task DeleteUserReport(int userReportId, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные жалобы.
    /// </summary>
    /// <param name="userReportId">Идентификатор жалобы.</param>
    /// <param name="userReportDto">Обновленная модель представления жалобы.</param>
    public Task UpdateUserReport(int userReportId, UserReportDto userReportDto, CancellationToken cancellation);
}