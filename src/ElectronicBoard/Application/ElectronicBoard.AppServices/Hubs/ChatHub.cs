using ElectronicBoard.AppServices.Chat.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;

/// <summary>
/// Хаб для работы с чатом.
/// </summary>

namespace ElectronicBoard.AppServices.Hubs;

[SignalRHub]
public class ChatHub : Hub
{
    private readonly IChatService _chatService;

    public ChatHub(IChatService chatService)
    {
        _chatService = chatService;
    }

   
    public async Task Send(string message)
    {
        
        await Clients.All.SendAsync("Receive", message);
    }
    
    
    public async Task Connect()
    {
        var messages = await _chatService.Connect(new CancellationToken());
        await Clients.Caller.SendAsync("ReceiveAll", messages);
    }
}