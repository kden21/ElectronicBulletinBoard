using ElectronicBoard.AppServices.Chat.Conversation.Services;
using ElectronicBoard.AppServices.Chat.ConversationMember.Services;
using ElectronicBoard.AppServices.Chat.Message.Services;
using ElectronicBoard.Contracts.Chat.Conversation;
using ElectronicBoard.Contracts.Chat.Message;

namespace ElectronicBoard.AppServices.Chat.Services;

/// <inheritdoc />
public class ChatService: IChatService
{
    private readonly IMessageService _messageService;
    private readonly IConversationService _conversationService;
    private readonly IConversationMemberService _conversationMemberService;

    public ChatService(IMessageService messageService, IConversationService conversationService, IConversationMemberService conversationMemberService)
    {
        _messageService = messageService;
        _conversationService = conversationService;
        _conversationMemberService = conversationMemberService;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<MessageDto>> Connect(int conversationId, CancellationToken cancellationToken)
    {
        return await _messageService.GetFilterMessages(conversationId, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<int> CreateConversation(int[] userIds, CancellationToken cancellationToken)
    {
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

    /// <inheritdoc />
    public async Task<MessageDto> CreateMessage(MessageDto model, CancellationToken cancellationToken)
    {
        return await _messageService.CreateMessage(model, cancellationToken);
    }

    public async Task<IEnumerable<ConversationDto>?> GetConversations(int userId, CancellationToken cancellationToken)
    {
        return await _conversationService.GetConversations(userId, cancellationToken);
    }
}