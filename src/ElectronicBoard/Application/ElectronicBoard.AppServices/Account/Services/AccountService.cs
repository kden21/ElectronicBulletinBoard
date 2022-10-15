using AutoMapper;
using ElectronicBoard.AppServices.Account.Helpers;
using ElectronicBoard.AppServices.Account.Repositories;
using ElectronicBoard.Contracts.Account.Dto;
using ElectronicBoard.Contracts.Account.LoginAccount.Request;
using ElectronicBoard.Contracts.Account.LoginAccount.Response;
using ElectronicBoard.Contracts.Shared.Filters;
using ElectronicBoard.Domain;
using ElectronicBoard.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ElectronicBoard.AppServices.Account.Services;

/// <inheritdoc />
public class AccountService : IAccountService
{
    private readonly IMapper _mapper;
    private readonly IAccountRepository _accountRepository;
    private readonly IConfiguration _configuration;

    public AccountService(IMapper mapper, IAccountRepository accountRepository, IConfiguration configuration)
    {
        _mapper = mapper;
        _accountRepository = accountRepository;
        _configuration = configuration;
    }

    /// <inheritdoc />
    public async Task<AccountDto> GetAccountById(int accountId, CancellationToken cancellation)
    {
        var accountEntity = await _accountRepository.GetAccountEntityById(accountId, cancellation);
        return _mapper.Map<AccountDto>(accountEntity);
    }

    public async Task<AccountDto> RegisterAccount(AccountDto accountDto, CancellationToken cancellation)
    {
        var account = await _accountRepository.GetAccountEntityByEmail(accountDto.Login, cancellation);
        if (account != null)
        {
            throw new WrongDataException("Пользователь с таким логином уже существует");
        }
        var accountEntity = _mapper.Map<AccountEntity>(accountDto);
        accountEntity.Password = AccountHelper.HashPassword(accountEntity.Password);
        int id = await _accountRepository.AddAccountEntity(accountEntity, cancellation);
        accountDto.Id = id;
        //RegisterAccountResponse response = null;
        //response.JWTToken = accountEntity.CreateJwtToken(_configuration);
        return accountDto;
        
    }

    public async Task<LoginAccountResponse> LoginAccount(LoginAccountRequest accountRequest, CancellationToken cancellation)
    {
        var account = _accountRepository
            .Where(a => a.Login.ToLower() == accountRequest.Login.ToLower()).Include(a=>a.User).FirstOrDefault();
        
        if (account == null || account.Password != accountRequest.Password.HashPassword())
        {
            throw new WrongDataException("Неверная почта или пароль");
        }
    
        LoginAccountResponse response = new LoginAccountResponse
        {
            JWTToken = account.CreateJwtToken(_configuration)
        };

        return await Task.FromResult(response);
    }
    
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