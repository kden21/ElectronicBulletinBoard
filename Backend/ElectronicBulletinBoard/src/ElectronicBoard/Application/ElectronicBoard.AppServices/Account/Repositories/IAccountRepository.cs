using System.Linq.Expressions;
using ElectronicBoard.Contracts.Shared.Filters;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Account.Repositories;

/// <summary>
/// Репозиторий для работы с аккаунтами <see cref="AccountEntity"/>.
/// </summary>
public interface IAccountRepository
{
    /// <summary>
    /// Возвращает аккаунт по e-mail.
    /// </summary>
    /// <param name="email">E-mail аккаунта</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Аккаунт<see cref="AccountEntity"/></returns>
    public Task<AccountEntity?> GetAccountEntityByEmail(string email, CancellationToken cancellation);
    
    /// <summary>
    /// Возвращает полный список аккаунтов.
    /// </summary>
    /// <returns>Коллекция аккаунтов <see cref="AccountEntity"/>.</returns>
    public Task<IEnumerable<AccountEntity>> GetAllAccountEntities(AccountFilterRequest? accountFilter, CancellationToken cancellation);

    /// <summary>
    /// Возвращает аккаунт по идентификатору.
    /// </summary>
    /// <param name="accountId">Идентификатор аккаунта.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Аккаунт <see cref="AccountEntity"/>.</returns>
    public Task<AccountEntity?> GetAccountEntityById(int accountId, CancellationToken cancellation);

    /// <summary>
    /// Добавляет аккаунт.
    /// </summary>
    /// <param name="accountModel">Аккаунт. <see cref="AccountEntity"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Идентификатор аккаунта <see cref="AccountEntity"/>.</returns>
    public Task<int> AddAccountEntity(AccountEntity accountModel, CancellationToken cancellation);

    /// <summary>
    /// Обновляет данные аккаунта.
    /// </summary>
    /// <param name="accountModel">Аккаунт. <see cref="AccountEntity"/>.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task UpdateAccountEntity(AccountEntity accountModel, CancellationToken cancellation);

    /// <summary>
    /// Удаляет аккаунта.
    /// </summary>
    /// <param name="accountId">Идентификатор аккаунта.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    public Task DeleteAccountEntity(int accountId, CancellationToken cancellation);

    /// <summary>
    /// Возвращает коллекцию аккаунтов, подходящих под условие выборки.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public IQueryable<AccountEntity> Where(Expression<Func<AccountEntity, bool>> predicate);
}