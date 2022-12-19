using ElectronicBoard.AppServices.Chat.Message.Repositories;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Domain.Chat;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.DataAccess.Repositories.Chat;

public class MessageRepository: IMessageRepository
{
    private readonly IRepository<MessageEntity> _repository;

    public MessageRepository(IRepository<MessageEntity> repository)
    {
        _repository = repository;
    }

    public async Task<MessageEntity> AddMessageEntity(MessageEntity messageEntity, CancellationToken cancellationToken)
    {
        var messageId = await _repository.AddEntity(messageEntity, cancellationToken);
        return await _repository.GetEntityById(messageId, cancellationToken);
    }

    public async Task<IEnumerable<MessageEntity>> GetFilterMessageEntities(int conversationId, CancellationToken cancellation)
    {
        return await _repository.GetAllEntities().Where(m=>m.ConversationId==conversationId)
            .OrderBy(c=>c.CreateDate).ToListAsync(cancellation);
    }
}