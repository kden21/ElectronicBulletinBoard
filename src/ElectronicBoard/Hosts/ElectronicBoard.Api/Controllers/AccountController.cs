using System.Net;
using ElectronicBoard.AppServices.Services.Account;
using ElectronicBoard.Contracts.Dto;
using ElectronicBoard.Contracts.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicBoard.Api.Controllers;

/// <summary>
/// Работа с аккаунтом.
/// </summary>
[ApiController]
[Produces("application/json")]
[Route("v1/accounts")]
public class AccountController : ControllerBase
{
    private readonly ILogger<AccountController> _logger;
    private readonly IAccountService _accountService;

    public AccountController(ILogger<AccountController> logger, IAccountService accountService)
    {
        _logger = logger;
        _accountService = accountService;
    }
    
    /// <summary>
    /// Возвращает коллекцию аккаунтов.
    /// </summary>
    /// <returns>Коллекция аккаунтов <see cref="AccountDto"/>.</returns>
    [HttpGet(Name = "GetAccounts")]
    [ProducesResponseType(typeof(IReadOnlyCollection<AccountDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll([FromQuery]AccountFilterRequest accountFilter)
    {
        return Ok(await _accountService.GetAllAccounts(accountFilter));
    }
    
    /// <summary>
    /// Возвращает аккаунта по Id.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <returns>Аккаунт <see cref="AccountDto"/>.</returns>
    [HttpGet("{accountId:int}", Name = "GetAccountById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(AccountDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById(int accountId)
    {
        return Ok(await _accountService.GetAccountById(accountId));
    }

    /// <summary>
    /// Добавляет новый аккаунт.
    /// </summary>
    /// <returns></returns>
    [HttpPost(Name = "CreateAccount")]
    [ProducesResponseType(typeof(AccountDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> Create([FromBody] AccountDto model)
    {
        model = await _accountService.CreateAccount(model);
        return CreatedAtAction("GetById", new { accountId = model.Id }, model);
    }
    
    /// <summary>
    /// Обновляет данные аккаунта.
    /// </summary>
    /// <param name="accountId">Идентификатор аккаунта.</param>
    /// <param name="accountDto">Аккаунт.</param>
    [HttpPut("{accountId:int}", Name = "UpdateAccount")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Update(int accountId, [FromBody]AccountDto accountDto)
    {
        await _accountService.UpdateAccount(accountId, accountDto);
        return Ok();
    }
    
    /// <summary>
    /// Удаляет аккаунта.
    /// </summary>
    /// <param name="accountId">Идентификатор аккаунта.</param>
    [HttpDelete("{accountId:int}", Name = "DeleteAccount")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(int accountId)
    {
        await _accountService.DeleteAccount(accountId);
        return NoContent();
    }
}