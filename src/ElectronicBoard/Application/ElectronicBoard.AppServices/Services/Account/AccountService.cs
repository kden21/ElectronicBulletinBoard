using AutoMapper;
using ElectronicBoard.AppServices.Repositories;
using ElectronicBoard.Contracts.Dto;
using ElectronicBoard.Contracts.Filters;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Services.Account;

/// <inheritdoc />
public class AccountService : IAccountService
{
    private readonly IMapper _mapper;
    private readonly IAccountRepository _accountRepository;

    public AccountService(IMapper mapper, IAccountRepository accountRepository)
    {
        _mapper = mapper;
        _accountRepository = accountRepository;
    }

    /// <inheritdoc />
    public async Task<AccountDto> GetAccountById(int accountId)
    {
        var accountEntity = await _accountRepository.GetAccountEntityById(accountId);
        return _mapper.Map<AccountDto>(accountEntity);
    }

    /// <inheritdoc />
    public async Task<AccountDto> CreateAccount(AccountDto accountDto)
    {
        var accountEntity = _mapper.Map<AccountEntity>(accountDto);
        var id = await _accountRepository.AddAccountEntity(accountEntity);
        accountDto.Id = id;
        return accountDto;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<AccountDto>> GetAllAccounts(AccountFilterRequest? accountFilter)
    {
        return _mapper.Map<IEnumerable<AccountEntity>, IEnumerable<AccountDto>>(await _accountRepository.GetAllAccountEntities(accountFilter));
    }

    /// <inheritdoc />
    public async Task DeleteAccount(int accountId)
    {
        await _accountRepository.DeleteAccountEntity(accountId);
    }

    /// <inheritdoc />
    public async Task UpdateAccount(int accountId, AccountDto accountDto)
    {
        accountDto.Id = accountId;
        var account = _mapper.Map<AccountEntity>(accountDto);
        await _accountRepository.UpdateAccountEntity(account);
    }
}