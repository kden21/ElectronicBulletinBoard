using ElectronicBoard.Domain.Chat;

namespace ElectronicBoard.AppServices.Chat.Conversation.Repositories;

public interface IConversationRepository
{
    public Task<int> CreateConversation(CancellationToken cancellation);
    public Task<IEnumerable<ConversationEntity>?> GetConversationIds(int userId, CancellationToken cancellationToken);

    //public Task<int> GetConversationByMembersId(int members1Id, int members2Id, CancellationToken cancellationToken);
    public Task<ConversationEntity?> GetConversationIdByUserIds(int[] userIds, CancellationToken cancellationToken);
}