using AutoMapper;
using ElectronicBoard.AppServices.Chat.Conversation.Repositories;
using ElectronicBoard.AppServices.Chat.ConversationMember.Repositories;
using ElectronicBoard.AppServices.Chat.ConversationMember.Services;
using ElectronicBoard.Contracts.Chat.Conversation;
using ElectronicBoard.Domain.Chat;

namespace ElectronicBoard.AppServices.Chat.Conversation.Services;

public class ConversationService:IConversationService
{
    private readonly IConversationRepository _conversationRepository;
    private readonly IMapper _mapper;

    public ConversationService(IConversationRepository conversationRepository, IConversationMemberRepository conversationMemberRepository, IConversationMemberService conversationMemberService, IMapper mapper)
    {
        _conversationRepository = conversationRepository;
        _mapper = mapper;
        //_conversationMemberService = conversationMemberService;
        //_conversationMemberRepository = conversationMemberRepository;
    }

    public async Task<int> CreateConversation(CancellationToken cancellation)
    {
        return await _conversationRepository.CreateConversation(cancellation);
    }

    public async Task<ConversationEntity?> GetConversationIdByUserIds(int[] userIds, CancellationToken cancellationToken)
    {
        return await _conversationRepository.GetConversationIdByUserIds(userIds, cancellationToken);
    }

    public async Task<IEnumerable<ConversationDto>?> GetConversationIds(int userId, CancellationToken cancellationToken)
    {
        return _mapper.Map<IEnumerable<ConversationEntity>, IEnumerable<ConversationDto>>(await _conversationRepository.GetConversationIds(userId, cancellationToken));

    }
}