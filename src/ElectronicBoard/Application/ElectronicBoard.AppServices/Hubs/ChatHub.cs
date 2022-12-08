using ElectronicBoard.AppServices.Chat.Services;
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

   
    public async Task Send(string message)
    {
        
        await Clients.All.SendAsync("Receive", message);
    }
    
    
    public async Task Connect()
    {
       // await _chatService.GetConversationByMembersId(int[] membersId,new CancellationToken());
        //await _chatService.CreateConversation(new CancellationToken());
        var messages = await _chatService.Connect(new CancellationToken());
        await Clients.Caller.SendAsync("ReceiveAll", messages);
    }
}