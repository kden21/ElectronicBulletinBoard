using ElectronicBoard.Contracts.Shared.Filters;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.User.Repositories;

/// <summary>
/// Репозиторий для работы с пользователями <see cref="UserEntity"/>.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Возвращает фильтрованную коллекцию пользователей.
    /// </summary>
    /// <returns>Коллекция пользователей <see cref="UserEntity"/>.</returns>
    public Task<IEnumerable<UserEntity>> GetFilterUserEntities(UserFilterRequest? userFilter, CancellationToken cancellation);

    
    /// <summary>
    /// Возвращает полную коллекцию пользователей.
    /// </summary>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Коллекция пользователей</returns>
    public Task<IEnumerable<UserEntity>> GetAllUserEntities(CancellationToken cancellation);

    /// <summary>
    /// Возвращает пользователя по идентификатору.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Пользователь <see cref="UserEntity"/>.</returns>
    public Task<UserEntity?> GetUserEntityById(int userId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет пользователя.
    /// </summary>
    /// <param name="userModel">Пользователь <see cref="UserEntity"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Идентификатор пользователя <see cref="UserEntity"/>.</returns>
    public Task<int> AddUserEntity(UserEntity userModel, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные пользователя.
    /// </summary>
    /// <param name="userModel">Пользователь <see cref="UserEntity"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task UpdateUserEntity(UserEntity userModel, CancellationToken cancellation);

    /// <summary>
    /// Удаляет пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя <see cref="UserEntity"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task DeleteUserEntity(int userId, CancellationToken cancellation);

    /// <summary>
    /// Изменяет статус пользователя на неактивный профиля.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя <see cref="UserEntity"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task SoftDeleteUserEntity(int userId, CancellationToken cancellation);
    
    /// <summary>
    /// Возвращает пользователя по идентификатору аккаунта.
    /// </summary>
    /// <param name="accountId">Идентификатор аккаунта.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Пользователь <see cref="UserEntity"/></returns>
    public Task<UserEntity> GetUserEntityByAccountId(int accountId, CancellationToken cancellation);
}