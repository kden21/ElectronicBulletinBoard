using ElectronicBoard.Contracts.Shared.Filters;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.User.Repositories;

/// <summary>
/// Репозиторий для работы с пользователями <see cref="UserEntity"/>.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Возвращает полный список пользователей.
    /// </summary>
    /// <returns>Коллекция пользователей <see cref="UserEntity"/>.</returns>
    public Task<IEnumerable<UserEntity>> GetAllUserEntities(UserFilterRequest? userFilter, CancellationToken cancellation);
    
    /// <summary>
    /// Возвращает пользователя по идентификатору.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <returns>Пользователь <see cref="UserEntity"/>.</returns>
    public Task<UserEntity?> GetUserEntityById(int userId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет пользователя.
    /// </summary>
    /// <param name="userModel">Пользователь <see cref="UserEntity"/>.</param>
    /// <returns>Идентификатор пользователя <see cref="UserEntity"/>.</returns>
    public Task<int> AddUserEntity(UserEntity userModel, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные пользователя.
    /// </summary>
    /// <param name="userModel">Пользователь <see cref="UserEntity"/>.</param>
    public Task UpdateUserEntity(UserEntity userModel, CancellationToken cancellation);

    /// <summary>
    /// Удаляет пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя <see cref="UserEntity"/>.</param>
    public Task DeleteUserEntity(int userId, CancellationToken cancellation);
}