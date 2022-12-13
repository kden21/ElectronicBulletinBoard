using ElectronicBoard.Domain.Chat;

namespace ElectronicBoard.AppServices.Chat.Message.Repositories;

/// <summary>
/// Репозиторий для работы с сообщениями.
/// </summary>
public interface IMessageRepository
{
    /// <summary>
    /// Добавляет сообщение.
    /// </summary>
    /// <param name="messageEntity"></param>
    /// <param name="cancellationToken">Маркер отмены.</param>
    /// <returns>Сообщение <see cref="MessageEntity"/>.</returns>
    public Task<MessageEntity> AddMessageEntity(MessageEntity messageEntity, CancellationToken cancellationToken);
    
    /// <summary>
    /// Возвращает коллекцию сообщений конкретной беседы.
    /// </summary>
    /// <param name="conversationId"> Идентификатор беседы.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Коллекция сообщений.</returns>
    public Task<IEnumerable<MessageEntity>> GetFilterMessageEntities(int conversationId, CancellationToken cancellation);
}