
using AutoMapper;
using ElectronicBoard.AppServices.Chat.Message.Repositories;
using ElectronicBoard.Contracts.Chat.Message;
using ElectronicBoard.Domain.Chat;

namespace ElectronicBoard.AppServices.Chat.Message.Services;

/// <inheritdoc />
public class MessageService: IMessageService
{
    private readonly IMessageRepository _messageRepository;
    private readonly IMapper _mapper;

    public MessageService(IMessageRepository messageRepository, IMapper mapper)
    {
        _messageRepository = messageRepository;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<MessageDto> CreateMessage(MessageDto model, CancellationToken cancellationToken)
    {
        var messageEntity = _mapper.Map<MessageEntity>(model);
        await _messageRepository.AddMessageEntity(messageEntity, cancellationToken);
        return _mapper.Map<MessageDto>(messageEntity);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<MessageDto>> GetFilterMessages(int conversationId, CancellationToken cancellation)
    {
        return _mapper.Map<IEnumerable<MessageEntity>, IEnumerable<MessageDto>>(await _messageRepository.GetFilterMessageEntities(conversationId, cancellation));
    }
}