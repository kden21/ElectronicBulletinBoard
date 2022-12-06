using ElectronicBoard.Domain.Chat;

namespace ElectronicBoard.AppServices.Chat.Message.Repositories;

public interface IMessageRepository
{
    public Task<IEnumerable<MessageEntity>> GetFilterMessageEntities( CancellationToken cancellation);
}