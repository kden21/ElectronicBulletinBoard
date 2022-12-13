using ElectronicBoard.Contracts.Chat.Message;

namespace ElectronicBoard.AppServices.Chat.Message.Services;

/// <summary>
/// Сервис для работы с сообщениями.
/// </summary>
public interface IMessageService
{
    /// <summary>
    /// Добавляет сообщение.
    /// </summary>
    /// <param name="model">Модель представления сообщения <see cref="MessageDto"/></param>
    /// <param name="cancellationToken">Маркер отмены.</param>
    /// <returns>Сообщение <see cref="MessageDto"/></returns>
    public Task<MessageDto> CreateMessage(MessageDto model, CancellationToken cancellationToken);
    
    /// <summary>
    /// Возвращает коллекцию сообщений по идентификатору беседы.
    /// </summary>
    /// <param name="conversationId">Идентификатор беседы.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Коллекция сообщений <see cref="MessageDto"/>.</returns>
    public Task<IEnumerable<MessageDto>> GetFilterMessages(int conversationId, CancellationToken cancellation);
}