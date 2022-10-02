using ElectronicBoard.AppServices.Repositories;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Contracts.Filters;
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
    public async Task<IEnumerable<AccountEntity>> GetAllAccountEntities(AccountFilterRequest? accountFilter)
    {
        return await _repository.GetAllEntities().OrderBy(c=>c.Id).Take(accountFilter.Count).Skip(accountFilter.Offset).ToListAsync();
    }

    /// <inheritdoc />
    public async Task<AccountEntity?> GetAccountEntityById(int accountId)
    {
        return await _repository.GetEntityById(accountId);
    }

    /// <inheritdoc />
    public async Task<int> AddAccountEntity(AccountEntity accountModel)
    {
        await _repository.AddEntity(accountModel);
        return accountModel.Id;
    }

    /// <inheritdoc />
    public async Task UpdateAccountEntity(AccountEntity accountModel)
    {
        await _repository.UpdateEntity(accountModel);
    }

    /// <inheritdoc />
    public async Task DeleteAccountEntity(int accountId)
    {
        await _repository.DeleteEntity(accountId);
    }
}