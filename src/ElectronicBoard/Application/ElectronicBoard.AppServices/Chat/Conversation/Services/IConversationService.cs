using ElectronicBoard.Domain.Chat;

namespace ElectronicBoard.AppServices.Chat.Conversation.Services;

public interface IConversationService
{
    //TODO:Нужен ли этот метод?
    public Task<int> CreateConversation(CancellationToken cancellation);

    public Task<ConversationEntity?> GetConversationIdByUserIds(int[] userIds, CancellationToken cancellationToken);
    //public Task<int> GetConversationByMembersId(int[] membersId, CancellationToken cancellationToken);
}