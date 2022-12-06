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

    public async Task<IEnumerable<MessageEntity>> GetFilterMessageEntities( CancellationToken cancellation)
    {
        return await _repository.GetAllEntities().OrderBy(c=>c.Id).ToListAsync(cancellation);
    }
}