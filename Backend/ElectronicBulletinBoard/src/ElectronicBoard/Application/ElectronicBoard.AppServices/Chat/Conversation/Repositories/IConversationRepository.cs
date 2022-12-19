using ElectronicBoard.Domain.Chat;

namespace ElectronicBoard.AppServices.Chat.Conversation.Repositories;

/// <summary>
/// Репозитеория для работы с беседами в чате.
/// </summary>
public interface IConversationRepository
{
    /// <summary>
    /// Добавляет новую беседу.
    /// </summary>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Идентификатор беседы.</returns>
    public Task<int> CreateConversation(CancellationToken cancellation);
    
    /// <summary>
    /// Возвращает коллекцию бесед конкретного пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">Маркер отмены.</param>
    /// <returns>Коллекция бесед <see cref="ConversationEntity"/>.</returns>
    public Task<IEnumerable<ConversationEntity>?> GetConversationIds(int userId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Возвращает беседу, в которой находят пользователи.
    /// </summary>
    /// <param name="userIds">Список идентификаторов пользователя.</param>
    /// <param name="cancellationToken">Маркер отмены.</param>
    /// <returns>Беседа <see cref="ConversationEntity"/>.</returns>
    public Task<ConversationEntity?> GetConversationIdByUserIds(int[] userIds, CancellationToken cancellationToken);
}