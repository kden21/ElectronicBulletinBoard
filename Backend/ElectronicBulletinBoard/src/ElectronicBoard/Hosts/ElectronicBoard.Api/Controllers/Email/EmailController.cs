using System.Net;
using ElectronicBoard.AppServices.EmailSendler;
using ElectronicBoard.Contracts.EmailSendler;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicBoard.Api.Controllers.Email;

/// <summary>
/// Контроллер для работы с EmailService
/// </summary>
[ApiController]
[Produces("application/json")]
[Route("v1/email")]
public class EmailController: ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    /// <summary>
    /// Формирует и отправляет на EmailService сообщение с обратной связью от пользователей.
    /// </summary>
    /// <param name="emailRequest"></param>
    /// <param name="cancellation">Маркёр отмены.</param>
    [HttpPost("feed_back")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> EmailFeedBack([FromBody]EmailFeedBackRequest emailRequest, CancellationToken cancellation)
    {
        await _emailService.EmailFeedBack(emailRequest, cancellation);
        return Ok();
    } 
}