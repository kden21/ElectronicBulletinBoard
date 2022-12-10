using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Chat.ConversationMember.Repositories;

public interface IConversationMemberRepository
{
    public Task<IEnumerable<int>?> GetMemberById(int userId, CancellationToken cancellationToken);
    public Task CreateMemberEntity(int userId, int conversationId, CancellationToken cancellationToken);
}