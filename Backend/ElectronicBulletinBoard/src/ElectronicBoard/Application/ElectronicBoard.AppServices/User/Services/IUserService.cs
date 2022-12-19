using ElectronicBoard.Contracts.Shared.Filters;
using ElectronicBoard.Contracts.User.Dto;

namespace ElectronicBoard.AppServices.User.Services;

/// <summary>
/// Сервис для работы с пользователем <see cref="UserDto"/>.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Возвращает пользователя по Id.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Модель представления пользователя <see cref="UserDto"/>.</returns>
    public Task<UserDto> GetUserById(int userId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет пользователя.
    /// </summary>
    /// <param name="userDto">Модель представления пользователя без Id <see cref="UserDto"/></param>
    /// <param name="cancellation"></param>
    /// <returns>Модель представления пользователя <see cref="UserDto"/></returns>
    public Task<UserDto> CreateUser(UserDto userDto, CancellationToken cancellation);

    /// <summary>
    /// Возвращает фильтрованную коллекцию пользователей.
    /// </summary>
    /// <param name="userFilter">Параметр фильтрации.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Коллекция пользователей <see cref="UserDto"/>.</returns>
    public Task<IEnumerable<UserDto>> GetFilterUsers(UserFilterRequest? userFilter, CancellationToken cancellation);

    /// <summary>
    /// Возвращает полную коллекцию пользователей.
    /// </summary>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns></returns>
    public Task<IEnumerable<UserDto>> GetAllUsers(CancellationToken cancellation);

    /// <summary>
    /// Удаляет пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task DeleteUser(int userId, CancellationToken cancellation);

    /// <summary>
    /// Изменяет статус пользователя на неактивный профиль.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task SoftDeleteUser(int userId, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="userDto">Обновленная модель представления пользователя.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task UpdateUser(int userId, UserDto userDto, CancellationToken cancellation);
}