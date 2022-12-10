using ElectronicBoard.Contracts.Chat.Conversation;
using ElectronicBoard.Contracts.Chat.Message;

namespace ElectronicBoard.AppServices.Chat.Services;

public interface IChatService
{
   public Task<IEnumerable<MessageDto>> Connect(int conversationId, CancellationToken cancellationToken);
   public Task<int> CreateConversation(int[] usersId,CancellationToken cancellationToken);
   public Task<MessageDto> CreateMessage(MessageDto model, CancellationToken cancellationToken);
   public Task<IEnumerable<ConversationDto>?> GetConversationIds(int userId, CancellationToken cancellationToken);
}