using ElectronicBoard.Contracts.Account.Dto;
using ElectronicBoard.Contracts.Account.LoginAccount.Request;
using ElectronicBoard.Contracts.Account.LoginAccount.Response;
using ElectronicBoard.Contracts.Shared.Filters;

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
    /// <returns>Модель представления аккаунта <see cref="AccountDto"/>.</returns>
    public Task<AccountDto> GetAccountById(int AccountId, CancellationToken cancellation);

    public Task<AccountDto> RegisterAccount(AccountDto accountDto, CancellationToken cancellation);

    /// <summary>
    /// Добавляет аккаунт.
    /// </summary>
    /// <param name="AccountDto">Модель представления аккаунта без Id <see cref="AccountDto"/></param>
    /// <returns>Модель представления аккаунта <see cref="AccountDto"/></returns>
    public Task<AccountDto> CreateAccount(AccountDto accountDto, CancellationToken cancellation);

    /// <summary>
    /// Возвращает фильтрованную/полную коллекцию аккаунтов.
    /// </summary>
    /// <param name="filterRequest">Параметр фильтрации.</param>
    /// <returns>Коллекция аккаунтов <see cref="AccountDto"/>.</returns>
    public Task<IEnumerable<AccountDto>> GetAllAccounts(AccountFilterRequest? accountFilter, CancellationToken cancellation);

    /// <summary>
    /// Удаляет аккаунт.
    /// </summary>
    /// <param name="accountId">Идентификатор аккаунта.</param>
    public Task DeleteAccount(int accountId, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные аккаунта.
    /// </summary>
    /// <param name="accountId">Идентификатор аккаунта.</param>
    /// <param name="accountDto">Обновленная модель представления аккаунта.</param>
    public Task UpdateAccount(int accountId, AccountDto accountDto, CancellationToken cancellation);

    public Task<LoginAccountResponse> LoginAccount(LoginAccountRequest accountRequest, CancellationToken cancellation);

}