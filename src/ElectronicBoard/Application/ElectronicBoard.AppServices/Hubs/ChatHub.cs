using ElectronicBoard.AppServices.Chat.Services;
using ElectronicBoard.Contracts.Chat.Message;
using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;



namespace ElectronicBoard.AppServices.Hubs;

/// <summary>
/// Хаб для работы с чатом.
/// </summary>
[SignalRHub]
public class ChatHub : Hub
{
    private readonly IChatService _chatService;

    public ChatHub(IChatService chatService)
    {
        _chatService = chatService;
    }

   
    public async Task Send(MessageDto message)
    {
        var messageResult = await _chatService.CreateMessage(message, new CancellationToken());
        await Clients.All.SendAsync("Receive", messageResult);
    }
    
    
    public async Task Connect(int conversationId)
    {
        var messages = await _chatService.Connect(conversationId, new CancellationToken());
        await Clients.Caller.SendAsync("ReceiveAll", messages);
    }
}