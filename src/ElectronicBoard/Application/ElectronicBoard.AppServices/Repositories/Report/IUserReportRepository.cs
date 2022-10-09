using ElectronicBoard.Contracts.Filters.Report;
using ElectronicBoard.Domain.Report;

namespace ElectronicBoard.AppServices.Repositories.Report;

/// <summary>
/// Репозиторий для работы с жалобами на пользователей <see cref="UserReportEntity"/>>
/// </summary>
public interface IUserReportRepository
{
    /// <summary>
    /// Возвращает полный список жалоб.
    /// </summary>
    /// <returns>Коллекция жалоб <see cref="UserReportEntity"/>.</returns>
    public Task<IEnumerable<UserReportEntity>> GetAllUserReportEntities(UserReportFilterRequest? userReportFilter, CancellationToken cancellation);
    
    /// <summary>
    /// Возвращает жалобу по идентификатору.
    /// </summary>
    /// <param name="userReportId">Идентификатор жалобы.</param>
    /// <returns>Жалоба <see cref="UserReportEntity"/>.</returns>
    public Task<UserReportEntity?> GetUserReportEntityById(int userReportId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет жалобу.
    /// </summary>
    /// <param name="userReportModel">Жалоба <see cref="UserReportEntity"/>.</param>
    /// <returns>Идентификатор жалобы <see cref="UserReportEntity"/>.</returns>
    public Task<int> AddUserReportEntity(UserReportEntity userReportModel, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные жалобы.
    /// </summary>
    /// <param name="userReportModel">Жалоба <see cref="UserReportEntity"/>.</param>
    public Task UpdateUserReportEntity(UserReportEntity userReportModel, CancellationToken cancellation);

    /// <summary>
    /// Удаляет жалобу.
    /// </summary>
    /// <param name="userReportId">Идентификатор жалобы <see cref="UserReportEntity"/>.</param>
    public Task DeleteUserReportEntity(int userReportId, CancellationToken cancellation);
}