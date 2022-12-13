
namespace ElectronicBoard.AppServices.Chat.ConversationMember.Services;

/// <summary>
/// Сервис для работы с членами чата.
/// </summary>
public interface IConversationMemberService
{
    /// <summary>
    ///  Возвращает коллекцию идентификаторов членов чата, по идентификатору пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <param name="cancellationToken">Маркер отмены.</param>
    /// <returns>Коллекцию идентификаторов членов чата</returns>
    public Task<IEnumerable<int>?> GetMemberIdByUserId(int userId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Добавляет нового члена чата.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="conversationId">Идентификатор беседы</param>
    /// <param name="cancellationToken">Маркер отмены.</param>
    /// <returns></returns>
    public Task CreateMember(int userId, int conversationId, CancellationToken cancellationToken);
}