using System.Net;
using ElectronicBoard.AppServices.Chat.Services;
using ElectronicBoard.Contracts.Advt.Dto;
using ElectronicBoard.Contracts.Chat.Conversation;
using ElectronicBoard.Contracts.Chat.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicBoard.Api.Controllers;

/// <summary>
/// Контроллер для работы с чатом.
/// </summary>

[ApiController]
[Produces("application/json")]
[Route("v1/chat")]
public class ChatController: ControllerBase
{
    private readonly IChatService _chatService;

    public ChatController(IChatService chatService)
   {
       _chatService = chatService;
   }

    /// <summary>
    /// Добавляет новую беседу между пользоателями.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpPost(Name = "CreateConversation")]
    [ProducesResponseType(typeof(AdvtDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    [Authorize]
    public async Task<IActionResult> CreateAsync([FromBody] CreateConversationRequest request, CancellationToken cancellation)
    {
        return Ok(await _chatService.CreateConversation(request.UsersId, cancellation));
    }

    /// <summary>
    /// Возвращает коллекцию бесед пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellation">Маркёр отмены.</param>
    /// <returns></returns>
    [HttpGet(Name = "GetConversations")]
    [ProducesResponseType(typeof(AdvtDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    [Authorize]
    public async Task<IActionResult> GetConversations([FromQuery] int userId, CancellationToken cancellation)
    {
        return Ok(await _chatService.GetConversations(userId, cancellation));
    }
    
    /// <summary>
    /// Добавляет новое сообщение.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpPost("create_message",Name = "CreateMessage")]
    [ProducesResponseType(typeof(AdvtDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    [Authorize]    
    public async Task<IActionResult> CreateMessage([FromBody] MessageDto model, CancellationToken cancellation)
    {
        await _chatService.CreateMessage(model, cancellation);
        return Ok(model.ConversationId);
    }

}