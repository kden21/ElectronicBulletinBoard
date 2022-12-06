using AutoMapper;
using ElectronicBoard.AppServices.Chat.Message.Services;
using ElectronicBoard.Contracts.Chat.Message;
using Microsoft.OpenApi.Models;

namespace ElectronicBoard.AppServices.Chat.Services;

public class ChatService: IChatService
{
    private readonly IMessageService _messageService;
    private readonly IMapper _mapper;

    public ChatService(IMessageService messageService, IMapper mapper)
    {
        _messageService = messageService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MessageDto>> Connect(CancellationToken cancellationToken)
    {
        return await _messageService.GetFilterMessages(cancellationToken);
    }
    
}