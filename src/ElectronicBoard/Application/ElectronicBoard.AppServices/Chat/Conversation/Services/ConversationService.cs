using ElectronicBoard.AppServices.Chat.Conversation.Repositories;
using ElectronicBoard.AppServices.Chat.ConversationMember.Repositories;
using ElectronicBoard.AppServices.Chat.ConversationMember.Services;
using ElectronicBoard.Domain.Chat;

namespace ElectronicBoard.AppServices.Chat.Conversation.Services;

public class ConversationService:IConversationService
{
    private readonly IConversationRepository _conversationRepository;

    public ConversationService(IConversationRepository conversationRepository, IConversationMemberRepository conversationMemberRepository, IConversationMemberService conversationMemberService)
    {
        _conversationRepository = conversationRepository;
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



    /*public async Task<int> GetConversationByMembersId(int[] usersId, CancellationToken cancellationToken)
    {
        var member1Id=_conversationMemberService.GetMemberIdByUserId(usersId[0], cancellationToken);
        var member2Id=_conversationMemberService.GetMemberIdByUserId(usersId[0], cancellationToken);
        //int[] membersId = new int[];
        //return await _conversationRepository.GetConversationByMembersId(member1Id, member2Id, cancellationToken);
    }*/
}