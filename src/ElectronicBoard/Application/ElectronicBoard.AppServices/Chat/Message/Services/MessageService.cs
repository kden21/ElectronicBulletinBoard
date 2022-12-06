
using AutoMapper;
using ElectronicBoard.AppServices.Chat.Message.Repositories;
using ElectronicBoard.Contracts.Chat.Message;
using ElectronicBoard.Domain.Chat;

namespace ElectronicBoard.AppServices.Chat.Message.Services;

public class MessageService: IMessageService
{
    private readonly IMessageRepository _messageRepository;
    private readonly IMapper _mapper;

    public MessageService(IMessageRepository messageRepository, IMapper mapper)
    {
        _messageRepository = messageRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MessageDto>> GetFilterMessages( CancellationToken cancellation)
    {
        return _mapper.Map<IEnumerable<MessageEntity>, IEnumerable<MessageDto>>(await _messageRepository.GetFilterMessageEntities(cancellation));
    }
}