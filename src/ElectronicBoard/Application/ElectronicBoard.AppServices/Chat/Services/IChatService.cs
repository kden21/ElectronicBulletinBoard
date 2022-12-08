using ElectronicBoard.Contracts.Chat.Message;

namespace ElectronicBoard.AppServices.Chat.Services;

public interface IChatService
{
   public Task<IEnumerable<MessageDto>> Connect(CancellationToken cancellationToken);
   public Task<int> CreateConversation(int[] usersId,CancellationToken cancellationToken);
   //public Task<int> GetConversationByMembersId(int[] membersId, CancellationToken cancellationToken);
}