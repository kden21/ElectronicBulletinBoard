using ElectronicBoard.Contracts.Account.Dto;
using ElectronicBoard.Contracts.Account.LoginAccount.Request;
using ElectronicBoard.Contracts.Account.LoginAccount.Response;
using ElectronicBoard.Contracts.Account.RegisterAccount;

namespace ElectronicBoard.AppServices.Account.Services;

/// <summary>
/// Сервис для работы с аккаунтом <see cref="AccountDto"/>.
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Возвращает аккаунт по Id.
    /// </summary>
    /// <param name="accountId">Идентификатор аккаунта.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Модель представления аккаунта <see cref="AccountDto"/>.</returns>
    public Task<AccountDto> GetAccountById(int accountId, CancellationToken cancellation);
    
    /// <summary>
    /// Добавляет аккаунт.
    /// </summary>
    /// <param name="accountDto">Модель представления аккаунта <see cref="AccountDto"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns></returns>
    public Task<AccountDto> RegisterAccount(RegisterRequest accountDto, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные аккаунта: смена пароля с подтверждением почты пользователя.
    /// </summary>
    /// <param name="accountId">Идентификатор аккаунта.</param>
    /// <param name="accountRequest">Данные для логина пользователя.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task PasswordChangeInAccount(int accountId, LoginAccountRequest accountRequest, CancellationToken cancellation);

    /// <summary>
    /// Проверяет валидность логина и пароля пользователя.
    /// </summary>
    /// <param name="accountRequest">Модель запроса данных для логина пользователя.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Идентификатор пользователя, токен авторизации.</returns>
    public Task<LoginAccountResponse> LoginAccount(LoginAccountRequest accountRequest, CancellationToken cancellation);

    /// <summary>
    /// Подтверждение e-mail.
    /// </summary>
    /// <param name="accountId">Идентификатор аккаунта.</param>
    /// <param name="userCode">Код подтверждения почты.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task EmailConfirm(int accountId, int userCode, CancellationToken cancellation);

    /// <summary>
    /// Восстановление пароля.
    /// </summary>
    /// <param name="receiverMail">E-mail пользователя.</param>
    /// <param name="receiverName">Имя пользователя.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Идентификатор аккаунта.</returns>
    public Task<int> PasswordRecoverySendler(string receiverMail, CancellationToken cancellation);
}