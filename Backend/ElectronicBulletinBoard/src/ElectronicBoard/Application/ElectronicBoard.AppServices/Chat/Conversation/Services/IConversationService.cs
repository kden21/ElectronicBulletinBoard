using ElectronicBoard.Contracts.Chat.Conversation;

namespace ElectronicBoard.AppServices.Chat.Conversation.Services;

/// <summary>
/// Сервис для работы с беседами чата.
/// </summary>
public interface IConversationService
{
    /// <summary>
    /// Добавляет новую беседу.
    /// </summary>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Идентификатор беседы.</returns>
    public Task<int> CreateConversation(CancellationToken cancellation);
    
    /// <summary>
    /// Возвращает коллекцию бесед пользователя.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken">Маркер отмены.</param>
    /// <returns>Коллекция бесед.</returns>
    public Task<IEnumerable<ConversationDto>?> GetConversations(int userId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Возвращает беседу, в которой находятся пользователи.
    /// </summary>
    /// <param name="userIds">Список идентификаторов пользователей</param>
    /// <param name="cancellationToken">Маркер отмены.</param>
    /// <returns>Беседа <see cref="ConversationDto"/>></returns>
    public Task<ConversationDto?> GetConversationIdByUserIds(int[] userIds, CancellationToken cancellationToken);
}