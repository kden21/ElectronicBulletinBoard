using System.Net;
using ElectronicBoard.AppServices.Chat.Services;
using ElectronicBoard.Contracts.Advt.Dto;
using ElectronicBoard.Contracts.Chat.Conversation;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicBoard.Api.Controllers;

[ApiController]
[Produces("application/json")]
[Route("v1/chat")]
public class ChatController: ControllerBase
{
    private readonly ILogger<AdvtController> _logger;

    private readonly IChatService _chatService;


   public ChatController(ILogger<AdvtController> logger, IChatService chatService)
   {
       _logger = logger;
       _chatService = chatService;
   }

    [HttpPost(Name = "CreateConversation")]
    [ProducesResponseType(typeof(AdvtDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    
    public async Task<IActionResult> CreateAsync([FromBody] CreateConversationRequest request, CancellationToken cancellation)
    {
        return Ok(await _chatService.CreateConversation(request.UsersId, cancellation));
    }
}