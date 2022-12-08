using ElectronicBoard.Contracts.Chat.ConversationMember;

namespace ElectronicBoard.AppServices.Chat.ConversationMember.Services;

public interface IConversationMemberService
{
    public Task<IEnumerable<int>?> GetMemberIdByUserId(int userId, CancellationToken cancellationToken);
    public Task CreateMember(int userId, int conversationId, CancellationToken cancellationToken);
}