using System.Linq.Expressions;
using ElectronicBoard.AppServices.Account.Repositories;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Contracts.Shared.Filters;
using ElectronicBoard.Domain;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.DataAccess.Repositories;

/// <inheritdoc />
public class AccountRepository : IAccountRepository
{
    private readonly IRepository<AccountEntity> _repository;

    public AccountRepository(IRepository<AccountEntity> repository)
    {
        _repository = repository;
    }

    /// <inheritdoc />
    public async Task<AccountEntity?> GetAccountEntityByEmail(string login, CancellationToken cancellation)
    {
        return await _repository.GetAllEntities().FirstOrDefaultAsync(a => a.Login.ToLower() == login.ToLower(), cancellation);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<AccountEntity>> GetAllAccountEntities(AccountFilterRequest? accountFilter, CancellationToken cancellation)
    {
        return await _repository.GetAllEntities().OrderBy(c=>c.Id).Take(accountFilter.Count)
            .Skip(accountFilter.Offset).ToListAsync(cancellation);
    }

    /// <inheritdoc />
    public async Task<AccountEntity?> GetAccountEntityById(int accountId, CancellationToken cancellation)
    {
        return await _repository.GetEntityById(accountId, cancellation);
    }

    /// <inheritdoc />
    public async Task<int> AddAccountEntity(AccountEntity accountModel, CancellationToken cancellation)
    {
        await _repository.AddEntity(accountModel, cancellation);
        return accountModel.Id;
    }
    
    /// <inheritdoc />
    public IQueryable<AccountEntity> Where(Expression<Func<AccountEntity, bool>> predicate)
    {
        return _repository.Where(predicate);
    }

    /// <inheritdoc />
    public async Task UpdateAccountEntity(AccountEntity accountModel, CancellationToken cancellation)
    {
        await _repository.UpdateEntity(accountModel, cancellation);
    }

    /// <inheritdoc />
    public async Task DeleteAccountEntity(int accountId, CancellationToken cancellation)
    {
        await _repository.DeleteEntity(accountId, cancellation);
    }
}