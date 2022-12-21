using System.Net;
using ElectronicBoard.AppServices.Chat.Services;
using ElectronicBoard.Contracts.Chat.Message;
using Microsoft.AspNetCore.Mvc;
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

    /// <summary>
    /// Иницилизирует экзепляр класса <see cref="ChatHub"/>.
    /// </summary>
    /// <param name="chatService">Сервис для работы с чатом.</param>
    public ChatHub(IChatService chatService)
    {
        _chatService = chatService;
    }

    /// <summary>
    /// Метод отправки сообщения.
    /// </summary>
    /// <param name="message">Сообщение <see cref="MessageDto"/></param>
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task Send(MessageDto message)
    {
        var messageResult = await _chatService.CreateMessage(message, new CancellationToken());
        await Clients.Group(message.ConversationId.ToString()).SendAsync("Receive", messageResult);
    }
    
    /// <summary>
    /// Метод присоединения к чату.
    /// </summary>
    /// <param name="conversationId">Идентификатор беседы.</param>
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task Connect(int conversationId)
    {
        var messages = await _chatService.Connect(conversationId, new CancellationToken());
        await Groups.AddToGroupAsync(Context.ConnectionId,  conversationId.ToString());
        await Clients.Caller.SendAsync("ReceiveAll", messages);
    }
}