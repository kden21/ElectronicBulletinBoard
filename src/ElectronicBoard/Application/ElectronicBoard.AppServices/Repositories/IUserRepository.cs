using ElectronicBoard.Contracts.Filters;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Repositories;

/// <summary>
/// Репозиторий для работы с пользователями <see cref="UserEntity"/>.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Возвращает полный список пользователей.
    /// </summary>
    /// <returns>Коллекция пользователей <see cref="UserEntity"/>.</returns>
    public Task<IEnumerable<UserEntity>> GetAllUserEntities(UserFilterRequest? userFilter);
    
    /// <summary>
    /// Возвращает пользователя по идентификатору.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <returns>Пользователь <see cref="UserEntity"/>.</returns>
    public Task<UserEntity?> GetUserEntityById(int userId);

    /// <summary>
    /// Добавляет пользователя.
    /// </summary>
    /// <param name="userModel">Пользователь <see cref="UserEntity"/>.</param>
    /// <returns>Идентификатор пользователя <see cref="UserEntity"/>.</returns>
    public Task<int> AddUserEntity(UserEntity userModel);

    /// <summary>
    /// Обновляет данные пользователя.
    /// </summary>
    /// <param name="userModel">Пользователь <see cref="UserEntity"/>.</param>
    public Task UpdateUserEntity(UserEntity userModel);

    /// <summary>
    /// Удаляет пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя <see cref="UserEntity"/>.</param>
    public Task DeleteUserEntity(int userId);
}