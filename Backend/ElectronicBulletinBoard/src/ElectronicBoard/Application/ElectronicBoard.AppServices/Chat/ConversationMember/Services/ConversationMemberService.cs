using AutoMapper;
using ElectronicBoard.AppServices.Chat.ConversationMember.Repositories;

namespace ElectronicBoard.AppServices.Chat.ConversationMember.Services;

/// <inheritdoc />
public class ConversationMemberService: IConversationMemberService
{
    private readonly IConversationMemberRepository _conversationMemberRepository;

    public ConversationMemberService(IConversationMemberRepository conversationMemberRepository, IMapper mapper)
    {
        _conversationMemberRepository = conversationMemberRepository;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<int>?> GetMemberIdByUserId(int userId, CancellationToken cancellationToken)
    {
        return await _conversationMemberRepository.GetMemberById(userId, cancellationToken);
    }
    
    /// <inheritdoc />
    public async Task CreateMember(int userId, int conversationId, CancellationToken cancellationToken)
    {
        await _conversationMemberRepository.CreateMemberEntity(userId, conversationId, cancellationToken);
    }
}