using ElectronicBoard.Contracts.Chat.Conversation;
using ElectronicBoard.Contracts.Chat.Message;

namespace ElectronicBoard.AppServices.Chat.Services;

/// <summary>
/// Сервис для работы с чатом.
/// </summary>
public interface IChatService
{
   /// <summary>
   /// Возвращает коллекцию сообщений беседы по ее идентификатору.
   /// </summary>
   /// <param name="conversationId">Идентификатор беседы.</param>
   /// <param name="cancellationToken">Маркер отмены.</param>
   /// <returns></returns>
   public Task<IEnumerable<MessageDto>> Connect(int conversationId, CancellationToken cancellationToken);
   
   /// <summary>
   /// Создает беседу.
   /// </summary>
   /// <param name="userIds">Идентификаторы пользователей.</param>
   /// <param name="cancellationToken">Маркер отмены.</param>
   /// <returns>Идентификатор беседы.</returns>
   public Task<int> CreateConversation(int[] userIds,CancellationToken cancellationToken);
   
   /// <summary>
   /// Добавляет сообщение.
   /// </summary>
   /// <param name="model">Модель представления сообщения.</param>
   /// <param name="cancellationToken">Маркер отмены.</param>
   /// <returns>Сообщение <see cref="MessageDto"/></returns>
   public Task<MessageDto> CreateMessage(MessageDto model, CancellationToken cancellationToken);
}