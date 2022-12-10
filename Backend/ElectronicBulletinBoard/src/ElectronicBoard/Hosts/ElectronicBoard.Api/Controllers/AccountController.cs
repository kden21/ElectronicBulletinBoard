using System.Net;
using ElectronicBoard.AppServices.Account.Services;
using ElectronicBoard.AppServices.User.Services;
using ElectronicBoard.Contracts.Account.Dto;
using ElectronicBoard.Contracts.Account.LoginAccount.Request;
using ElectronicBoard.Contracts.Account.RegisterAccount;
using ElectronicBoard.Contracts.EmailSendler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicBoard.Api.Controllers;

/// <summary>
/// Работа с аккаунтом.
/// </summary>
[ApiController]
[Produces("application/json")]
[Route("v1/account")]
public class AccountController : ControllerBase
{
    private readonly ILogger<AccountController> _logger;
    private readonly IAccountService _accountService;
    
    public AccountController(ILogger<AccountController> logger, IAccountService accountService)
    {
        _logger = logger;
        _accountService = accountService;
    }
    
    [HttpPost("login")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> LoginAccount(LoginAccountRequest accountRequest, CancellationToken cancellation)
    {
        return Ok(await _accountService.LoginAccount(accountRequest, cancellation));
    } 
    
    [HttpPost("register")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> RegisterAccount([FromBody]RegisterRequest model, CancellationToken cancellation)
    {
        return Ok(await _accountService.RegisterAccount(model, cancellation));
    }
    
    [HttpPost("{accountId}/emailConfirm")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> EmailConfirm(int accountId, [FromBody]int userCode, CancellationToken cancellation)
    {
        await _accountService.EmailConfirm(accountId, userCode, cancellation);
        return Ok();
    }
    
    [HttpPost("password_recovery")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> PasswordRecoverySendler([FromBody]EmailRequest emailRequest, CancellationToken cancellation)
    {
        return Ok( await _accountService.PasswordRecoverySendler(emailRequest.ReceiverMail, emailRequest.ReceiverName, cancellation));
    }
    
    /*[HttpPost("emailSend")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> EmailSendler([FromBody]EmailRequest request, CancellationToken cancellation)
    {
        _accountService.EmailSendlerMessage(request, cancellation);
        return Ok();
    }*/
    
    /*/// <summary>
    /// Возвращает коллекцию аккаунтов.
    /// </summary>
    /// <returns>Коллекция аккаунтов <see cref="AccountDto"/>.</returns>
    [HttpGet("GetAccounts")]
    [ProducesResponseType(typeof(IReadOnlyCollection<AccountDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll([FromQuery]AccountFilterRequest accountFilter, CancellationToken cancellation)
    {
        return Ok(await _accountService.GetAllAccounts(accountFilter, cancellation));
    }
    
    /// <summary>
    /// Возвращает аккаунта по Id.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <returns>Аккаунт <see cref="AccountDto"/>.</returns>
    [HttpGet("{accountId:int}", Name = "GetAccountById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(AccountDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById(int accountId, CancellationToken cancellation)
    {
        return Ok(await _accountService.GetAccountById(accountId, cancellation));
    }

    /// <summary>
    /// Добавляет новый аккаунт.
    /// </summary>
    /// <returns></returns>
    [HttpPost(Name = "CreateAccount")]
    [ProducesResponseType(typeof(AccountDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> Create([FromBody] AccountDto model, CancellationToken cancellation)
    {
        model = await _accountService.CreateAccount(model, cancellation);
        return CreatedAtAction("GetById", new { accountId = model.Id }, model);
    }*/
    
    /// <summary>
    /// Смена пароля.
    /// </summary>
    /// <param name="accountId">Идентификатор аккаунта.</param>
    [HttpPut("{accountId:int}/password_change", Name = "PasswordChange")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> PasswordChange(int accountId, [FromBody]LoginAccountRequest accountRequest, CancellationToken cancellation)
    {
        await _accountService.PasswordChangeInAccount(accountId, accountRequest, cancellation);
        return Ok();
    }
    
    /*/// <summary>
    /// Удаляет аккаунта.
    /// </summary>
    /// <param name="accountId">Идентификатор аккаунта.</param>
    [HttpDelete("{accountId:int}", Name = "DeleteAccount")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(int accountId, CancellationToken cancellation)
    {
        await _accountService.DeleteAccount(accountId, cancellation);
        return NoContent();
    }*/
}