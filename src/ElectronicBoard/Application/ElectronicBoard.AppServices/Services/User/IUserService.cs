using ElectronicBoard.Contracts.Dto;

namespace ElectronicBoard.AppServices.Services.User;

/// <summary>
/// Сервис для работы с пользователем <see cref="UserDto"/>.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Возвращает пользователя по Id.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <returns>Модель представления пользователя <see cref="UserDto"/>.</returns>
    public Task<UserDto> GetUserById(int userId);

    /// <summary>
    /// Добавляет пользователя.
    /// </summary>
    /// <param name="userDto">Модель представления пользователя без Id <see cref="UserDto"/></param>
    /// <returns>Модель представления пользователя <see cref="UserDto"/></returns>
    public Task<UserDto> CreateUser(UserDto userDto);

    /// <summary>
    /// Возвращает коллекцию пользователей.
    /// </summary>
    /// <returns>Коллекция пользователей <see cref="UserDto"/>.</returns>
    public IEnumerable<UserDto> GetAll();

    /// <summary>
    /// Удаляет пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    public Task DeleteUser(int userId);

    /// <summary>
    /// Обновляет данные пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="userDto">Обновленная модель представления пользователя.</param>
    public Task UpdateUser(int userId, UserDto userDto);
}