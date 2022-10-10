using AutoMapper;
using ElectronicBoard.AppServices.Helpers;
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
    public async Task<AccountDto> GetAccountById(int accountId, CancellationToken cancellation)
    {
        var accountEntity = await _accountRepository.GetAccountEntityById(accountId, cancellation);
        return _mapper.Map<AccountDto>(accountEntity);
    }

   /* public async Task<AccountDto> RegisterAccount(AccountDto accountDto, CancellationToken cancellation)
    {
        var account = await _accountRepository.GetAccountEntityByEmail(accountDto.Email, cancellation);
        if (account != null)
        {
            
        }
        
        
    }*/
    /// <inheritdoc />
    public async Task<AccountDto> CreateAccount(AccountDto accountDto, CancellationToken cancellation)
    {
        var accountEntity = _mapper.Map<AccountEntity>(accountDto);
        var id = await _accountRepository.AddAccountEntity(accountEntity, cancellation);
        accountDto.Id = id;
        return accountDto;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<AccountDto>> GetAllAccounts(AccountFilterRequest? accountFilter, CancellationToken cancellation)
    {
        return _mapper.Map<IEnumerable<AccountEntity>, IEnumerable<AccountDto>>(await _accountRepository.GetAllAccountEntities(accountFilter, cancellation));
    }

    /// <inheritdoc />
    public async Task DeleteAccount(int accountId, CancellationToken cancellation)
    {
        await _accountRepository.DeleteAccountEntity(accountId, cancellation);
    }

    /// <inheritdoc />
    public async Task UpdateAccount(int accountId, AccountDto accountDto, CancellationToken cancellation)
    {
        accountDto.Id = accountId;
        var account = _mapper.Map<AccountEntity>(accountDto);
        await _accountRepository.UpdateAccountEntity(account, cancellation);
    }
}