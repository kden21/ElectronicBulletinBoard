using AutoMapper;
using ElectronicBoard.AppServices.Chat.Conversation.Services;
using ElectronicBoard.AppServices.Chat.ConversationMember.Services;
using ElectronicBoard.AppServices.Chat.Message.Services;
using ElectronicBoard.Contracts.Chat.Message;
using Microsoft.OpenApi.Models;

namespace ElectronicBoard.AppServices.Chat.Services;

public class ChatService: IChatService
{
    private readonly IMessageService _messageService;
    private readonly IConversationService _conversationService;
    private readonly IConversationMemberService _conversationMemberService;
    private readonly IMapper _mapper;

    public ChatService(IMessageService messageService, IMapper mapper, IConversationService conversationService, IConversationMemberService conversationMemberService)
    {
        _messageService = messageService;
        _mapper = mapper;
        _conversationService = conversationService;
        _conversationMemberService = conversationMemberService;
    }

    public async Task<IEnumerable<MessageDto>> Connect(CancellationToken cancellationToken)
    {
        return await _messageService.GetFilterMessages(cancellationToken);
    }

    public async Task<int> CreateConversation(int[] userIds, CancellationToken cancellationToken)
    {

        /*await _conversationService.CreateConversation(cancellationToken);
        
        var conversations1 = await _conversationMemberService.GetMemberIdByUserId(usersId[0], cancellationToken);
        var conversations2 =await _conversationMemberService.GetMemberIdByUserId(usersId[1], cancellationToken);

        int conversationId = 0;

        var result = conversations1.Intersect(conversations2);
        
        if (result.Count() != 0)
            conversationId = result.ElementAt(0);
        
        else
        {
            conversationId = await _conversationService.CreateConversation(cancellationToken);
            await _conversationMemberService.CreateMember(usersId[0], conversationId, cancellationToken);
            await _conversationMemberService.CreateMember(usersId[1], conversationId, cancellationToken);
        }*/

        var conversation = await _conversationService.GetConversationIdByUserIds(userIds, cancellationToken);
        
        if (conversation == null)
        {
            int conversationId = await _conversationService.CreateConversation(cancellationToken);
            foreach (int userId in userIds)
            {
                await _conversationMemberService.CreateMember(userId, conversationId, cancellationToken);
            }
            return conversation!.Id;
        }
        else
        {
            return conversation.Id;
        }
    }
}