using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Repositories;

/// <summary>
/// Репозиторий для работы с пользователем <see cref="UserEntity"/>.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Возвращает полный список пользователей.
    /// </summary>
    /// <returns>Коллекция пользователей <see cref="UserEntity"/>.</returns>
    public IQueryable<UserEntity> GetAll();
    
    /// <summary>
    /// Возвращает пользователя по идентификатору.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <returns>Пользователь <see cref="UserEntity"/>.</returns>
    public Task<UserEntity?> GetByIdAsync(int userId);

    /// <summary>
    /// Добавляет пользователя.
    /// </summary>
    /// <param name="userModel">Пользователь <see cref="UserEntity"/>.</param>
    /// <returns>Идентификатор пользователя <see cref="UserEntity"/>.</returns>
    public Task<int> AddAsync(UserEntity userModel);

    /// <summary>
    /// Обновляет данные пользователя.
    /// </summary>
    /// <param name="userModel">Пользователь <see cref="UserEntity"/>.</param>
    public Task UpdateAsync(UserEntity userModel);

    /// <summary>
    /// Удаляет пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя <see cref="UserEntity"/>.</param>
    public Task DeleteAsync(int userId);
}