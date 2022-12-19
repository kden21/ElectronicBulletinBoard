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
    private readonly IAccountService _accountService;
    
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    /// <summary>
    /// Логин пользователя.
    /// </summary>
    /// <param name="accountRequest">Данные для логина.</param>
    /// <param name="cancellation">Маркёр отмены.</param>
    /// <returns></returns>
    [HttpPost("login")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> LoginAccount(LoginAccountRequest accountRequest, CancellationToken cancellation)
    {
        return Ok(await _accountService.LoginAccount(accountRequest, cancellation));
    } 
    
    /// <summary>
    /// Регистрация пользователя.
    /// </summary>
    /// <param name="model">Данные для регистрации.</param>
    /// <param name="cancellation">Маркёр отмены.</param>
    /// <returns></returns>
    [HttpPost("register")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> RegisterAccount([FromBody]RegisterRequest model, CancellationToken cancellation)
    {
        return Ok(await _accountService.RegisterAccount(model, cancellation));
    }
    
    /// <summary>
    /// Подверждение e-mail.
    /// </summary>
    /// <param name="accountId">Идентификатор аккаунта.</param>
    /// <param name="userCode">Код подтверждения.</param>
    /// <param name="cancellation">Маркёр отмены.</param>
    /// <returns></returns>
    [HttpPost("{accountId}/emailConfirm")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> EmailConfirm(int accountId, [FromBody]int userCode, CancellationToken cancellation)
    {
        await _accountService.EmailConfirm(accountId, userCode, cancellation);
        return Ok();
    }
    
    //TODO:какой из методов не используется?
    /// <summary>
    /// Смена пароля аккаунта.
    /// </summary>
    /// <param name="emailRequest"></param>
    /// <param name="cancellation">Маркёр отмены.</param>
    /// <returns></returns>
    [HttpPost("password_recovery")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> PasswordRecoverySendler([FromBody]EmailRequest emailRequest, CancellationToken cancellation)
    {
        return Ok( await _accountService.PasswordRecoverySendler(emailRequest.ReceiverMail, cancellation));
    }

    /// <summary>
    /// Смена пароля.
    /// </summary>
    /// <param name="accountId">Идентификатор аккаунта.</param>
    /// <param name="cancellation"></param>
    [HttpPut("{accountId:int}/password_change", Name = "PasswordChange")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> PasswordChange(int accountId, [FromBody]LoginAccountRequest accountRequest, CancellationToken cancellation)
    {
        await _accountService.PasswordChangeInAccount(accountId, accountRequest, cancellation);
        return Ok();
    }
}