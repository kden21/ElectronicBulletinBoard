using AutoMapper;
using ElectronicBoard.AppServices.Chat.Conversation.Repositories;
using ElectronicBoard.Contracts.Chat.Conversation;
using ElectronicBoard.Domain.Chat;

namespace ElectronicBoard.AppServices.Chat.Conversation.Services;
/// <inheritdoc />

public class ConversationService:IConversationService
{
    private readonly IConversationRepository _conversationRepository;
    private readonly IMapper _mapper;

    public ConversationService(IConversationRepository conversationRepository, IMapper mapper)
    {
        _conversationRepository = conversationRepository;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<int> CreateConversation(CancellationToken cancellation)
    {
        return await _conversationRepository.CreateConversation(cancellation);
    }

    /// <inheritdoc />
    public async Task<ConversationDto?> GetConversationIdByUserIds(int[] userIds, CancellationToken cancellationToken)
    {
        return _mapper.Map<ConversationEntity, ConversationDto>(await _conversationRepository.GetConversationIdByUserIds(userIds, cancellationToken));
    }

    /// <inheritdoc />
    public async Task<IEnumerable<ConversationDto>?> GetConversations(int userId, CancellationToken cancellationToken)
    {
        return _mapper.Map<IEnumerable<ConversationEntity>, IEnumerable<ConversationDto>>(await _conversationRepository.GetConversationIds(userId, cancellationToken));

    }
}