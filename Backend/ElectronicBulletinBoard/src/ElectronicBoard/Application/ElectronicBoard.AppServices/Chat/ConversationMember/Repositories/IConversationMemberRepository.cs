
namespace ElectronicBoard.AppServices.Chat.ConversationMember.Repositories;

/// <summary>
/// Сервис для работы с членами чата.
/// </summary>
public interface IConversationMemberRepository
{
    /// <summary>
    /// Возвращает коллекцию идентификаторов членов чата, по идентификатору пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">Маркер отмены.</param>
    /// <returns>Коллекцию идентификаторов членов чата</returns>
    public Task<IEnumerable<int>?> GetMemberById(int userId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Добавляет члена беседы.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="conversationId"></param>
    /// <param name="cancellationToken">Маркер отмены.</param>
    public Task CreateMemberEntity(int userId, int conversationId, CancellationToken cancellationToken);
}