using AutoMapper;
using ElectronicBoard.AppServices.Chat.ConversationMember.Repositories;
using ElectronicBoard.Contracts.Chat.ConversationMember;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Chat.ConversationMember.Services;

public class ConversationMemberService: IConversationMemberService
{
    private readonly IMapper _mapper;
    private readonly IConversationMemberRepository _conversationMemberRepository;

    public ConversationMemberService(IConversationMemberRepository conversationMemberRepository, IMapper mapper)
    {
        _conversationMemberRepository = conversationMemberRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<int>?> GetMemberIdByUserId(int userId, CancellationToken cancellationToken)
    {
        return await _conversationMemberRepository.GetMemberById(userId, cancellationToken);
    }

    public async Task CreateMember(int userId, int conversationId, CancellationToken cancellationToken)
    {
        await _conversationMemberRepository.CreateMemberEntity(userId, conversationId, cancellationToken);
    }
}