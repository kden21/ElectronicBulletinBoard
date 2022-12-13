using AutoMapper;
using ElectronicBoard.AppServices.Account.Helpers;
using ElectronicBoard.AppServices.Account.Repositories;
using ElectronicBoard.AppServices.EmailSendler;
using ElectronicBoard.AppServices.User.Repositories;
using ElectronicBoard.Contracts.Account.Dto;
using ElectronicBoard.Contracts.Account.LoginAccount.Request;
using ElectronicBoard.Contracts.Account.LoginAccount.Response;
using ElectronicBoard.Contracts.Account.RegisterAccount;
using ElectronicBoard.Contracts.Shared.Enums;
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
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public AccountService(IMapper mapper, IAccountRepository accountRepository, IConfiguration configuration, IUserRepository userRepository, IEmailService emailService)
    {
        _mapper = mapper;
        _accountRepository = accountRepository;
        _configuration = configuration;
        _userRepository = userRepository;
        _emailService = emailService;
    }

    /// <inheritdoc />
    public async Task<AccountDto> GetAccountById(int accountId, CancellationToken cancellation)
    {
        var accountEntity = await _accountRepository.GetAccountEntityById(accountId, cancellation);
        return _mapper.Map<AccountDto>(accountEntity);
    }

    /// <inheritdoc />
    public async Task<AccountDto> RegisterAccount(RegisterRequest registerRequestDto, CancellationToken cancellation)
    {
        var account = await _accountRepository.GetAccountEntityByEmail(registerRequestDto.Login, cancellation);
        if (account != null)
        {
            throw new WrongDataException("Пользователь с таким логином уже существует");
        }
        
        var accountEntity = _mapper.Map<AccountEntity>(registerRequestDto);
        accountEntity.Password = AccountHelper.HashPassword(accountEntity.Password);
        
        int userCode = await _emailService.EmailSendlerMessage(registerRequestDto.Login, registerRequestDto.Name, cancellation);
        accountEntity.UserCode = userCode.ToString().HashPassword();
     
        int id = await _accountRepository.AddAccountEntity(accountEntity, cancellation);
        
        var userEntity = _mapper.Map<UserEntity>(registerRequestDto);
        userEntity.AccountId = accountEntity.Id;
        await _userRepository.AddUserEntity(userEntity, cancellation);

        var accountDto = _mapper.Map<AccountDto>(accountEntity);
        accountDto.Id = id;
        
        return accountDto;
        
    }

    /// <inheritdoc />
    public async Task PasswordChangeInAccount(int accountId, LoginAccountRequest accountRequest, CancellationToken cancellation)
    {
        var accountEntity = await _accountRepository.GetAccountEntityById(accountId, cancellation);
        accountEntity.Password = accountRequest.Password.HashPassword();

        await _accountRepository.UpdateAccountEntity(accountEntity, cancellation);
    }

    /// <inheritdoc />
    public async Task<LoginAccountResponse> LoginAccount(LoginAccountRequest accountRequest, CancellationToken cancellation)
    {
        var account = _accountRepository
            .Where(a => a.Login.ToLower() == accountRequest.Login.ToLower()).Include(a=>a.User).FirstOrDefault();
        
        if (account == null || account.Password != accountRequest.Password.HashPassword())
        {
            throw new WrongDataException("Неверная почта или пароль");
        }

        if (account.User.StatusUser == StatusUser.AwaitingEmailConfirm)
        {
            throw new WrongDataException("Подтвердите почту, чтобы войти в аккаунт");
        }
    
        LoginAccountResponse response = new LoginAccountResponse
        {
            JWTToken = account.CreateJwtToken(_configuration),
            UserId = account.User.Id
        };

        return await Task.FromResult(response);
    }

    /// <inheritdoc />
    public async Task EmailConfirm(int accountId, int userCode, CancellationToken cancellation)
    {
        var accountEntity = await _accountRepository.Where(a => a.Id == accountId).FirstOrDefaultAsync(cancellation);
        if(accountEntity.UserCode==userCode.ToString().HashPassword())
        {
            var userEntity =await _userRepository.GetUserEntityByAccountId(accountEntity.Id, cancellation);
            userEntity.StatusUser = StatusUser.Actual;
            await _userRepository.UpdateUserEntity(userEntity, cancellation);
        }
        else
        {
            throw new NoConfirmEmailException("Неверный код подтверждения почты");
        }
    }

    /// <inheritdoc />
    public async Task<int> PasswordRecoverySendler(string receiverMail, string receiverName, CancellationToken cancellation)
    {
        var account = await _accountRepository.GetAccountEntityByEmail(receiverMail, cancellation);
        if (account == null)
        {
            throw new AccountNoExistsException("Аккаунт с такой почтой не существует");
        }
        int userCode = await _emailService.PasswordRecoverySendlerMessage(receiverMail, receiverName, cancellation);
        account.UserCode = userCode.ToString().HashPassword();
        await _accountRepository.UpdateAccountEntity(account, cancellation);
        return await Task.FromResult(account.Id);
    }
}