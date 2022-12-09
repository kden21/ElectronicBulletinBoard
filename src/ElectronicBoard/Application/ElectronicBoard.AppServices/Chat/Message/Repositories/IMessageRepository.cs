using ElectronicBoard.Contracts.Chat.Message;
using ElectronicBoard.Domain.Chat;

namespace ElectronicBoard.AppServices.Chat.Message.Repositories;

public interface IMessageRepository
{
    public Task<MessageEntity> AddMessageEntity(MessageEntity messageEntity, CancellationToken cancellationToken);
    public Task<IEnumerable<MessageEntity>> GetFilterMessageEntities(int conversationId, CancellationToken cancellation);
}